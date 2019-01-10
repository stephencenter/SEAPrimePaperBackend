using PrimePaper.Business.DataContract.SeedData;
using PrimePaper.Database.DataContract.SeedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimePaper.Business.SeedData
{
    public class SeedDataManager : ISeedDataManager
    {
        private ISeedRepository _seedRepository;

        public SeedDataManager(ISeedRepository seedRepository)
        {
            _seedRepository = seedRepository;
        }

        public void SeedUsers()
        {
            _seedRepository.SeedUsers();
        }
    }
}
