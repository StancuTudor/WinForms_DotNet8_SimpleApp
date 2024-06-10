using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Models;
using WinFormsApp1.Repositories;

namespace WinFormsApp1.Services
{
    public interface IMainService
    {
        Task<string> Test();
    }

    public class MainService : IMainService
    {
        private readonly IMainRepository _mainRepository;
        public MainService(IMainRepository mainRepository)
        {
            _mainRepository = mainRepository;
        }

        public async Task<string> Test()
        {
            return await _mainRepository.Test();
        }
    }
}
