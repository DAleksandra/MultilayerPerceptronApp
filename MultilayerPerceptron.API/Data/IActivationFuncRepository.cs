using MultilayerPerceptron.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultilayerPerceptron.API.Data
{
    public interface IActivationFuncRepository
    {
        Task<int> BipolarStepFunction(float value);
        

    }
}
