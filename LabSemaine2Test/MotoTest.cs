using ConsoleApp2;

namespace LabSemaine2Test
{
    [TestClass]
    public class MotoTest
    {
        string style;
        int tailleReservoir;
        int dureeVieKm;
        string couleur;
        string marque;
        string modele;
        Moto m;
        Roue roue;
        Moteur moteur;
        double distanceParcourue;
        private const string Expected = "Pour faire le tournant serré, vous avez dû incliner la moto.";


        [TestInitialize]
        public void Init()
        {
            distanceParcourue = 0.0;
            roue = new Roue(5, 85, 12, 21, 'V', 9, "ok");
            moteur = new Moteur(14, 7, 11, 21);
            dureeVieKm = 8;
            couleur = "Blue";
            marque = "Toyota";
            modele = "OK";
            tailleReservoir = 20;
            style = "Guillaume";
            m = new Moto(dureeVieKm, style, tailleReservoir, moteur, roue, couleur, marque, modele);

        }
        [TestCleanup]
        public void CleanUp()
        {
            distanceParcourue = 0.0;
            roue = null;
            moteur = null;
            dureeVieKm = 0;
            couleur = "";
            marque = "";
            modele = "";
            tailleReservoir = 0;
            style = "";
            m = null; ;
        }
        [TestMethod]
        public void Moto_ValeurCorrect_MotoMemeValeur()
        {

            Assert.AreEqual<int>(dureeVieKm, m.DureeVieKm);
            Assert.AreEqual<string>(style, m.Style);
            Assert.AreEqual<int>(tailleReservoir, m.TailleReservoir);
            Assert.AreEqual<Moteur>(moteur, m.Moteur);
            Assert.AreEqual<string>(couleur, m.Couleur);
            Assert.AreEqual<string>(marque, m.Marque);
            Assert.AreEqual<string>(modele, m.Modele);
            Assert.AreEqual<int>((int)Math.Floor(m.TailleReservoir / moteur.ConsommationParKm), m.AutonomieKm);
            Assert.AreEqual<int>(m.AnneeDeProduction, 2021);
        }
        [TestMethod]
        public void Moto_Roue_MemeValeur()
        {
            Assert.AreEqual<int>(roue.Largeur, m.Roues[0].Largeur);
            Assert.AreEqual<int>(roue.PourcentageHauteur, m.Roues[0].PourcentageHauteur);
            Assert.AreEqual<int>(roue.DiametreJante, m.Roues[0].DiametreJante);
            Assert.AreEqual<int>(roue.IndiceCharge, m.Roues[0].IndiceCharge);
            Assert.AreEqual<char>(roue.IndiceVitesse, m.Roues[0].IndiceVitesse);
            Assert.AreEqual<int>(roue.Pression, m.Roues[0].Pression);
            Assert.AreEqual<string>(roue.Type, m.Roues[0].Type);

        }
        [TestMethod]
        public void TournerSerrer_AffichageMessage_AfficheBonMessage()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                m.TournerSerrer();

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
            }
        }
        [TestMethod]
        public void AjouterUsure_AjoutUsure_UsureAjouter()
        {
            int ajout = 11;
            Assert.AreEqual<double>(distanceParcourue, m.DistanceParcourue);
            m.AjouterUsure(ajout);
            Assert.AreEqual<double>(distanceParcourue += ajout, m.DistanceParcourue);

        }
        [TestMethod]
        public void AjouterUsure_Affichage_BonMessage()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                m.AjouterUsure(200);

                var result = sw.ToString().Trim();
                Assert.AreEqual("Votre Moto a dépassée ça durée de vie, elle peut vous lâcher à tout moment !", result);
            }

        }
        [TestMethod]
        public void DiminuerPression_PressionDiminuer_PressionDiminiue()
        {
            Assert.AreEqual<int>(roue.Pression, m.Roues[1].Pression);
            m.DiminuerPression();
            Assert.AreEqual<int>(roue.Pression - 1, m.Roues[1].Pression);
        }
        [TestMethod]
        public void AjouterPression_PressionAjouter_PressionEguale35()
        {
            int pressionManquante = 35 - roue.Pression;
            Assert.AreEqual<int>(roue.Pression, m.Roues[1].Pression);
            m.AjouterPression();
            Assert.AreEqual<int>(roue.Pression + pressionManquante, m.Roues[1].Pression);
        }
        [TestMethod]
        public void FaireLePlein_AffichageMessage_AfficheBonMessage()
        {
            var valeur = "";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                m.TournerSerrer();
                m.AjouterPression();
                valeur = sw.ToString().Trim();
            }
            valeur += "\r\nVous avez fait le plein !";
            Init();
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                m.FaireLePlein();
                var texte = sw.ToString().Trim();
                Assert.AreEqual(valeur, texte);
            }

        }
        /*[TestMethod]
        public void Rouler_Affichage_BonMessage()
        {
            m.Rouler(200);
        }*/
        [TestMethod]
        public void Rouler_Affichage_BonMessageDistancePlusPetitAutonomie()
        {
            distanceParcourue = 10;
            m.AutonomieKm = 15;
            roue.Pression = 1000;
            dureeVieKm = 1000;
           
            var valeur = "";

            valeur += "Vous avez roulé " + 15 + " km. Vous devez faire le plein avant de continuer le voyage.\r\n" +
                "Pour faire le tournant serré, vous avez dû incliner la moto.\r\n" +
                "Vous avez gonflé le pneu.\r\n" +
                "Vous avez gonflé le pneu.\r\n" +
                "Vous avez fait le plein !\r\n" +
                "Vous avez roulé " + 15 + " km !\r\n" +
                "Pour faire le tournant serré, vous avez dû incliner la moto.\r\n" +
                "Vous avez fait le plein !\r\n" +
                "Votre Moto a dépassée ça durée de vie, elle peut vous lâcher à tout moment !\r\n" +
                "Le voyage est fini.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                m.Rouler(30);
                var texte1 = sw.ToString().Trim();
                Assert.AreEqual(valeur, texte1);
            }
        }
        [TestMethod]
        public void Rouler_Affichage_BonMessageDistancePlusGrandAutonomie()
        {
            distanceParcourue = 15;
            m.AutonomieKm = 10;
            roue.Pression = 1000;
            dureeVieKm = 1000;

            var valeur = "";

            valeur += "Vous avez roulé " + 10 + " km. Vous devez faire le plein avant de continuer le voyage.\r\n" +
                "Pour faire le tournant serré, vous avez dû incliner la moto.\r\n" +
                "Vous avez gonflé le pneu.\r\n" +
                "Vous avez gonflé le pneu.\r\n" +
                "Vous avez fait le plein !\r\n" +
                "Vous avez roulé " + 10 + " km. Vous devez faire le plein avant de continuer le voyage.\r\n" +
                "Pour faire le tournant serré, vous avez dû incliner la moto.\r\n" +
                "Vous avez fait le plein !\r\n" +
                "Vous avez roulé " + 10 + " km !\r\n" +
                "Pour faire le tournant serré, vous avez dû incliner la moto.\r\n" +
                "Vous avez fait le plein !\r\n" +
                "Votre Moto a dépassée ça durée de vie, elle peut vous lâcher à tout moment !\r\n" +
                "Le voyage est fini.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                m.Rouler(30);
                var texte1 = sw.ToString().Trim();
                Assert.AreEqual(valeur, texte1);
            }
        }
        [TestMethod]
        public void Rouler_Affichage_BonMessageDistancePlusPetitDureeVie()
        {
            distanceParcourue = 15;
            m.AutonomieKm = 1000;
            roue.Pression = 1000;
            dureeVieKm = 20;

            var valeur = "";

            valeur += "Vous avez roulé " + 30 + " km !\r\n" +
                "Pour faire le tournant serré, vous avez dû incliner la moto.\r\n" +
                "Vous avez gonflé le pneu.\r\n" +
                "Vous avez gonflé le pneu.\r\n" +
                "Vous avez fait le plein !\r\n" +
                "Votre Moto a dépassée ça durée de vie, elle peut vous lâcher à tout moment !\r\n" +
                "Le voyage est fini.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                m.Rouler(30);
                var texte1 = sw.ToString().Trim();
                Assert.AreEqual(valeur, texte1);
            }
        }
        [TestMethod]
        public void Rouler_Affichage_BonMessageDistancePlusGrandDureeVie()
        {
            distanceParcourue = 25;
            m.AutonomieKm = 1000;
            roue.Pression = 1000;
            dureeVieKm = 20;

            var valeur = "";

            valeur += "Vous avez roulé " + 30 + " km !\r\n" +
                "Pour faire le tournant serré, vous avez dû incliner la moto.\r\n" +
                "Vous avez gonflé le pneu.\r\n" +
                "Vous avez gonflé le pneu.\r\n" +
                "Vous avez fait le plein !\r\n" +
                "Votre Moto a dépassée ça durée de vie, elle peut vous lâcher à tout moment !\r\n" +
                "Le voyage est fini.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                m.Rouler(30);
                var texte1 = sw.ToString().Trim();
                Assert.AreEqual(valeur, texte1);
            }
        }

    }
}