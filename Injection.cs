using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CSharpAOT
{
    public unsafe class Injection
    {
        // dotnet publish -c Release -r win-x64 /tl

        [UnmanagedCallersOnly(EntryPoint = "DllMain", CallConvs = new[] { typeof(CallConvStdcall) })]
        public static bool DllMain(IntPtr hModule, uint ulReasonForCall, IntPtr lpReserved)
        {
            if (ulReasonForCall == 1)
            {
                _ = Utils.WinAPI.DisableThreadLibraryCalls(hModule);
                _ = Utils.WinAPI.CreateThread(null, 0, Main, null, 0, out _);
            }

            return true;
        }

        private static void Main()
        {
            var console_init = Utils.Cönsole.Initialize();

            if (console_init == Utils.Cönsole.InitializeResult.Console_Successfully)
            {
                Utils.Cönsole.Info("Created by Jan");
            }
        }
    }
}
