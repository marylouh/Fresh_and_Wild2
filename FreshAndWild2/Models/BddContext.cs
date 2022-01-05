using System;
using Microsoft.EntityFrameworkCore;

namespace FreshAndWild2.Models
{
    public class BddContext : DbContext
    {

        // ---------------------------------------User
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<Abonne> Abonnes { get; set; }
        public DbSet<Producteur> Producteurs { get; set; }
        public DbSet<Adresse> Adresses { get; set; }

        // ---------------------------------------Produit
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        public DbSet<LignePanier> LignesPanier { get; set; }
        public DbSet<Panier> Paniers { get; set; }

        // ---------------------------------------Paiement 
        public DbSet<PaiementInfo> PaiementInfos { get; set; }
        
        // ---------------------------------------Communauté 
        public DbSet<Activite> Activites { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<Session> Sessions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=FreshAndWild");
        }

        public BddContext()
        {
        }

        internal void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

            this.Adresses.AddRange(
                new Adresse
                {
                    Id = 1,
                    NumVoie = 15,
                    LibelleVoie = "Rue du Pont",
                    CodePostal = 75014,
                    Commune = "Paris",
                }
                ) ;


           this.PaiementInfos.AddRange(

                new PaiementInfo
                {
                    Id = 1,
                    NumeroCb = 495421564,
                    Titulaire = "Jeanne Priso",
                    ExpirationCb = "11/2022",
                    CodeCvc = 945,
                    //AdherentId = 3,

                },

                new PaiementInfo
                {
                    Id = 2,
                    NumeroCb = 495421564,
                    Titulaire = "Houria Benmokrane",
                    ExpirationCb = "11/2022",
                    CodeCvc = 165,
                    //AdherentId = 3,

                }
               );
            this.SaveChanges();

            this.Adherents.AddRange(

                new Adherent
                {
                    Id = 1,
                    Nom = "Admin",
                    Prenom = "Admin",
                    Email = "admin@freshandwild.com",
                    DateAdhesion = DateTime.Today,
                    MotDePasseConnexion = "admin123",
                    AdresseId = 1,
                    PaiementInfoId = 1,
                    Admin = true,
                },

                new Adherent
                {
                    Id = 2,
                    Nom = "Benmokrane",
                    Prenom = "Houria",
                    Email = "houria.b@gmail.com",
                    DateAdhesion = DateTime.Today,
                    MotDePasseConnexion = "123",
                    AdresseId = 1,
                    PaiementInfoId = 2,
                    AJour = true,
                    Admin = false,
                    
                },

                new Adherent
                {
                    Id = 3,
                    Nom = "Priso",
                    Prenom = "Jeanne",
                    Email = "jeanne.p@gmail.com",
                    DateAdhesion = DateTime.Today,
                    MotDePasseConnexion = "123",
                    AdresseId = 1,
                    PaiementInfoId = 1,
                    AJour = true,
                    Admin = false,

                }
            );
            this.SaveChanges();

            this.Producteurs.AddRange(
            new Producteur
            { NomFerme = "Au Petit bonheur Tranquille",
            Description = "Rambouillet (78), 34 hectares de terres cultivées."},

            new Producteur
            { NomFerme = "Les Fourches",
                Description = "Saclay (91), 50 hectares de terres cultivées."},

            new Producteur
            { NomFerme = "Lactel",
                Description = "Saint-Rémy-Les-Chevreuses (78), 30 vaches laitières et 40 hectares de pâturages."}
                )
                ;
            this.SaveChanges();


            this.Produits.AddRange(

                    new Produit
                    { Id = 51, Nom = "Confiture de poires ", ProducteurId = 2, Description = "Découvrez une recette à l’ancienne comme le faisait nos grands-mères ! Les poires gorgées de soleil et cueillies avec soin cuisent lentement, avec une pointe de vanille et juste ce qu’il faut de sucre dans de grands chaudrons de cuivre. Cette confiture vous charmera par sa texture gourmande et ses parfums exquis : un pur délice ! ", Conditionnement = "500g ", Prix = 12.50, Stock = 20 },

                   new Produit
                   { Id = 52, Nom = " Jambon de Paris", ProducteurId = 2, Description = " Le jambon de Paris est un jambon blanc cuit, désossé et sans couenne. (tranché approximativement 150g). Nos cochons sont élevés dans le Perche à la Bazoche-Gouet dans le respect de la qualité et de l’animal. Pour améliorer la qualité de la dégustation, retirer le produit de son emballage sous-vide et laissez-le reposer à l’air libre au minimum 45 minutes avant de le consommer. Date limite de consommation : 6 jours.", Conditionnement = "150g ", Prix = 13.2, Stock = 10 },

                   new Produit
                   { Id = 53, Nom = "Miel d'acacia", ProducteurId = 1, Description = " Le miel d'acacia est un miel Bleu Blanc Ruche origine France garantie. Facile et savoureux, capable de séduire les petits comme les grands. Sa douceur charmera les néophytes comme les passionnés de miel, qui l’utiliseront notamment pour son pouvoir sucrant, afin de remplacer le sucre dans leurs desserts ou leurs boissons chaudes.e  ", Conditionnement = "250g ", Prix = 12.99, Stock = 10 },

                   new Produit
                   { Id = 54, Nom = " Miel de la forêt", ProducteurId = 2, Description = " Respirez la bonne odeur de la forêt avec des senteurs de sous bois et de feuilles mortes. Le miel de forêt est le plus souvent brun foncé et liquide avec un parfum tannique, atypique et boisé. Le miel de forêt est une alternative économique aux miels BIO. ", Conditionnement = " 250g", Prix = 11.23, Stock = 15 },

                   new Produit
                   { Id = 55, Nom = " Miel des fleurs ", ProducteurId = 1, Description = " Le miel de fleurs de printemps est l'un des premiers récoltés dans l’année. Ce miel passe - partout présente de multiples atouts. Facile à tartiner, on s'en délecte au petit-déjeuner, sur des tartines ou dans un café. Doux et d’un goût assez neutre, il se cuisine très facilement : il remplacera élégamment le sucre dans vos préparations. ", Conditionnement = "100", Prix = 12.87, Stock = 10 },

                   new Produit
                   { Id = 56, Nom = " Trio de sauces", ProducteurId = 1, Description = " Sauces savoureuses avec une saveur de fumée profonde à base d'ingrédients soigneusement sélectionnés. Ils peuvent être utilisés pour n'importe quel plat ", Conditionnement = " 75cl x 3", Prix = 3, Stock = 11 },

                   new Produit

                   { Id = 57, Nom = " Camambert AOP ", ProducteurId = 1, Description = "Universellement connu, le Camembert est le fromage le plus copié. Les amateurs savent que le véritable Camembert provient des cinq départements de Normandie. Celui - ci est fabriqué au lait cru et moulé à la louche.Il porte la mention véritable Camembert de Normandie, au lait cru, moulé à la louche, 45 % de matières grasses comme gage de qualité. Un bon Camembert est affiné à coeur, a pâte est jaune clair au goût légèrement salé.Il a un goût délicat, subtile de terroir légèrement salé.Sa pâte est jaune clair, sa croûte est striée et parsemée d'un léger duvet blanc.", Conditionnement = "250g (pièce)", Prix = 7, Stock = 8 },




                   new Produit
                   { Id = 1, Nom = "Veggie Solo (Abonnement semestriel)", ProducteurId = 2, Description = "CONVIENT POUR 1 PERSONNE. ENVIRON 2,5KG", Prix = 325 },

                   new Produit
                   { Id = 2, Nom = "Greedy Solo (Abonnement semestriel)", ProducteurId = 1, Description = "CONVIENT POUR 1 PERSONNE. ENVIRON 2,5KG", Prix = 465.40 },

                   new Produit
                   { Id = 3, Nom = "Melange Duo (Abonnement semestriel)", ProducteurId = 1, Description = "CONVIENT POUR 2 PERSONNES. ENVIRON 4KG", Prix = 595.40 },

                   new Produit
                   { Id = 4, Nom = "Fruity Solo (Abonnement semestriel)", ProducteurId = 2, Description = "CONVIENT POUR 1 PERSONNE. ENVIRON 2,5KG", Prix = 335.40 },

                   new Produit
                   { Id = 5, Nom = "Greedy Duo (Abonnement semestriel)", ProducteurId = 2, Description = "CONVIENT POUR 2 PERSONNES. ENVIRON 4KG", Prix = 595.40 },

                   new Produit
                   { Id = 6, Nom = "Melange Famille (Abonnement semestriel)", ProducteurId = 1, Description = "CONVIENT POUR 2 PERSONNES. ENVIRON 4KG", Prix = 595.40 },

                   new Produit
                   { Id = 7, Nom = "Fruity Duo (Abonnement semestriel)", ProducteurId = 1, Description = "CONVIENT POUR 4 PERSONNES. ENVIRON 6,5KG", Prix = 595.40 },

                   new Produit
                   { Id = 8, Nom = "Fruity Famille (Abonnement semestriel)", ProducteurId = 2, Description = "CONVIENT POUR 4 PERSONNES. ENVIRON 6,5KG", Prix = 647.40 },

                   new Produit
                   { Id = 9, Nom = "Greedy Famille (Abonnement semestriel)", ProducteurId = 1, Description = "CONVIENT POUR 4 PERSONNES. ENVIRON 2,5KG", Prix = 725.40 }

                   )
                   ;
            this.SaveChanges();
            ;

            this.Activites.AddRange(
                     new Activite
                     {
                         Id = 1,

                         titre = "Cueillette des champignons",

                         Lieu = "Bessancourt",
                         Date = DateTime.Today,
                         NbreParticipant = 10,
                         Description = "",
                         valid = true

                     });
            this.SaveChanges();

        }
    }
}
