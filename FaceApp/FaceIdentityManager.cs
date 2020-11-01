using Microsoft.Azure.CognitiveServices.Vision.Face;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FaceIdentification
{
    public class FaceIdentityManager
    {
        private readonly IFaceClient _faceClient;
        private readonly string _recognitionModel = "recognition_03";

        public FaceIdentityManager(string faceApiEndpointUrl, string apiKey, string recognitionModel = "recognition_03")
        {
            if (string.IsNullOrEmpty(faceApiEndpointUrl))
                throw new ArgumentNullException("faceApiEndpointUrl");
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException("apiKey");
            if (string.IsNullOrEmpty(recognitionModel))
                throw new ArgumentNullException("recognitionModel");

            var credential = new ApiKeyServiceClientCredentials(apiKey);
            _faceClient = new FaceClient(credential)
            {
                Endpoint = faceApiEndpointUrl
            };

            _recognitionModel = recognitionModel;
        }

        public async Task<string> CreateIdentityPersonGroup(string groupName)
        {
            var groupId = Guid.NewGuid().ToString();
            await CreateIdentityPersonGroup(groupId, groupName);
            return groupId;
        }

        public async Task CreateIdentityPersonGroup(string groupId, string groupName)
        {
            await _faceClient.PersonGroup.CreateAsync(groupId, name: groupName, recognitionModel: _recognitionModel);
        }

        public async Task<Guid> AddPersonToGroup(string groupId, string name, byte[] faceImageData)
        {
            var stream = new MemoryStream(faceImageData);
            return await AddPersonToGroup(groupId, name, stream);
        }

        public async Task<Guid> AddPersonToGroup(string groupId, string name, Stream faceImageStream)
        {
            var person = await _faceClient.PersonGroupPerson.CreateAsync(groupId, name: name);
            var personId = person.PersonId;
            await _faceClient.PersonGroupPerson.AddFaceFromStreamAsync(groupId, personId, faceImageStream);
            return personId;
        }

        public async Task TrainPersonGroupModel(string groupId, int timeoutSeconds = 300)
        {
            var startTime = DateTime.Now;

            await _faceClient.PersonGroup.TrainAsync(groupId);

            while (true)
            {
                // get training status.
                var status = await _faceClient.PersonGroup.GetTrainingStatusAsync(groupId);

                if (status.Status == Microsoft.Azure.CognitiveServices.Vision.Face.Models.TrainingStatusType.Succeeded)
                    break;

                Thread.Sleep(250);

                if (((TimeSpan)(DateTime.Now - startTime)).TotalSeconds > timeoutSeconds)
                    throw new InvalidOperationException("Train model timeout reached.");
            }
        }

        public async Task<bool> IdentityFace(string groupId, Guid personId, Stream faceStream)
        {
            var faces = await _faceClient.Face.DetectWithStreamAsync(faceStream, recognitionModel: _recognitionModel);

            if (faces == null || !faces.Any())
                return false;

            var faceIds = faces.Select(x => x.FaceId).ToList();
            var result = await _faceClient.Face.IdentifyAsync(faceIds, groupId);

            if (!result.Select(x => x.Candidates.Count > 0).Any(x => x))
                return false;

            foreach (var foundFace in result)
            {
                foreach (var candidate in foundFace.Candidates)
                {
                    if (candidate.PersonId == personId)
                        return true;
                }
            }

            return false;
        }

        public async Task<IDictionary<string, bool>> IdentityFace(string groupId, Guid personId, IDictionary<string, Stream> identityFaceStreams)
        {
            var dict = new Dictionary<string, bool>();

            foreach (var identityFaceStream in identityFaceStreams)
            {
                var found = await IdentityFace(groupId, personId, identityFaceStream.Value);
                dict.Add(identityFaceStream.Key, found);                
            }

            return dict;
        }
    }
}
