using System.Threading.Tasks;

namespace MultilayerPerceptron.API.Data
{
     public class ActivationFunctionRepository : IActivationFuncRepository
    {
        public async Task<int> BipolarStepFunction(float value)
        {
            if( value < 0)
            {
                return -1;
            }

            return 1;
        }

        
    }
}