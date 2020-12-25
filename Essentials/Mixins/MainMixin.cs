using System;
using Essentials.Command;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using Terraria;
using Terraria.Localization;

namespace Essentials.Mixins
{
    [Mixin(typeof(Main))]
    public class MainMixin
    {
        private static string _theReadLine;

        [Redirect(
            At = AtLocation.Invoke,
            Method = MainTargets.Methods.startDedInputCallBack,
            Target = MainTargets.Methods.startDedInputCallBackInjects.Console_ReadLine)]
        private static string ReadLine()
        {
            return _theReadLine = Console.ReadLine();
        }

        [Redirect(
            At = AtLocation.Invoke,
            Method = MainTargets.Methods.startDedInputCallBack,
            Target = MainTargets.Methods.startDedInputCallBackInjects.Console_WriteLine_String)]
        [Unique]
        private static void WriteLine(string value)
        {
            if (value != Language.GetTextValue("CLI.InvalidCommand"))
                Console.WriteLine(value);
            else
                try
                {
                    CommandManager.Dispatcher.Execute(_theReadLine, new Source(null));
                }
                catch (Exception exception)
                {
                    Console.Error.WriteLine(exception);
                }
        }
    }
}
