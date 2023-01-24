namespace languageext_pipes_test;

using LanguageExt.Sys.Live;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
        => await MainIO<Runtime>.Get(args).RunUnit(Runtime.New());
}
