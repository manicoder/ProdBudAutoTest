using Prodat.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdBudAutoTest.Services
{
    //CurrentProcess
    public sealed class CurrentProcess
    {
        private static readonly Lazy<CurrentProcess> lazy =
            new Lazy<CurrentProcess>(() => new CurrentProcess());

        public static CurrentProcess Instance { get { return lazy.Value; } }
        public Sp_Process Proccess { get; set; }
        private CurrentProcess()
        {
        }
    }
}
