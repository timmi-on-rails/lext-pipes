using LanguageExt;
using LanguageExt.Pipes;
using LanguageExt.Sys;
using LanguageExt.Sys.Traits;
using System.ComponentModel.Design;
using System.Linq;
using static LanguageExt.Pipes.Proxy;
using static LanguageExt.Prelude;

namespace languageext_pipes_test;

internal class MainIO<RT>
    where RT : struct, HasConsole<RT>
{
    public static Aff<RT, Unit> Get(string[] args)
        => effect.RunEffect();

    static Effect<RT, Unit> effect
        => compose(  repeat(producer. Bind<Unit>(_ => 
        Producer.lift<RT, int, Unit>(Console<RT>.writeLine("test")))) | pipe | consumer;

    static Producer<RT, int, Unit> producer =>
        from _ in Console<RT>.writeLine("before")
        from i in enumerate<int, int>(new[] { 1, 2, 3 })
        from __ in yield(i)
        from ___ in Console<RT>.writeLine("after")
        select unit;

    static Pipe<RT, int, string, Unit> pipe =>
        from i in awaiting<int>()
        from _ in yield(i.ToString())
        select unit;

    static Consumer<RT, string, Unit> consumer =>
        from l in awaiting<string>()
        from _ in Console<RT>.writeLine(l)
        select unit;
}
