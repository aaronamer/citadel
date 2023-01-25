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

        public void Add(string name)
        {
            var model = new NameModel
            {
                Name = name
            };

            _repository.Names.Add(model);
            _repository.SaveChanges();
        }
    }
}
