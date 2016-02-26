using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
//using KleinenijnProject.KleinenijnFeatureSteps;

namespace KleinenijnTest
{    
    public partial class KleinenijnFeatureSteps2 
   {
   private static KleinenijnFeatureSteps GENERAL_STAPPEN = new KleinenijnFeatureSteps();
    
        [When(@"Ik zie dat de pagina geladen is en klik op de knop (.*)")]
        public void IkZieDatDePaginaGeladenIsEnKlikOpDeKnop(string Knop)
        {
            GENERAL_STAPPEN.IkZieDatDePaginaGeladenIs();
            GENERAL_STAPPEN.IkKlikOpDeKnop(Knop);
        }      
    }
}
