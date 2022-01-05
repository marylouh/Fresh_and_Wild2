using Xunit;
using System.Collections.Generic;
using FreshAndWild2.Models;

namespace TestUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Creation_Utilisateurs_Verification()
        {
            // Nous supprimons la base si elle existe puis nous la créons
            using (Dal ctx = new Dal())
            {
                // Nous supprimons et créons la db avant le test
                ctx.DeleteCreateDatabase();

                // Nous créons un utilisateur
                //ctx.CreerUtilisateur("Tutu", "Tata", 34, "0102030405", "ID_Con", "MDP_Con");

                // Nous vérifions que l'utilisateur a bien été créé
                List<Utilisateur> utilisateurs = ctx.ObtenirTousLesUtilisateurs();
                Assert.NotNull(utilisateurs);
                Assert.Single(utilisateurs);
                Assert.Equal("Tutu", utilisateurs[0].Nom);
            }
        }
    }
}
