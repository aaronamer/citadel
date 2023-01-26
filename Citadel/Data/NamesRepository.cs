using Citadel.Data.Models;

namespace Citadel.Data
{
    public class NamesRepository : INamesRepository
    {
        private readonly Repository _repository;

        public NamesRepository(Repository repository)
        {
            _repository = repository;
        }

        public async Task Add(string name)
        {
            var model = new NameModel
            {
                Name = name
            };

            _repository.Names.Add(model);
            await _repository.SaveChangesAsync();
        }
    }
}
