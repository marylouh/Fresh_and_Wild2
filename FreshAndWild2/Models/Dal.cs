using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace FreshAndWild2.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext;
        [Obsolete]
        private IHostingEnvironment _environment;
        
        public Dal()
        {
            //crée un canal d'accès aux données de la BDD
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            //efface et recrée la BDD à chaque lancement du programme
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public List<Utilisateur> ObtenirTousLesUtilisateurs()
        {
            return _bddContext.Utilisateurs.ToList();
        }

        public List<Adherent> ObtenirTousLesAdherents()
        {
            return _bddContext.Adherents.ToList();
        }

        //public List<Adresse> ObtenirToutesLesAdresses()
        //{
        //    return _bddContext.Adresses.ToList();
        //}
        // ---------------------------------------Paiement 
        public List<PaiementInfo> ObtenirTousLesPaiementsInfo()
        {
            return _bddContext.PaiementInfos.ToList();
        }
        // ---------------------------------------Paiement 

        public int CreerUtilisateur(string nom, string prenom, int age, string telephone, string v)
        {
            Utilisateur utilisateur = new Utilisateur { Nom = nom, Prenom = prenom, Age = age, Telephone = telephone };
            _bddContext.Utilisateurs.Add(utilisateur);
            _bddContext.SaveChanges();
            return utilisateur.Id;

        }

        public int CreerAdresse(int numVoie, string complement, string libelleVoie, string complementAdresse, int codePostal, string commune)
        {
            Adresse adresse = new Adresse { NumVoie = numVoie, Complement = complement, LibelleVoie = libelleVoie, ComplementAdresse = complementAdresse, CodePostal = codePostal, Commune = commune };
            _bddContext.Adresses.Add(adresse);
            _bddContext.SaveChanges();
            return adresse.Id;
        }

        public int CreerAdresse(Adresse adresse)
        {
            _bddContext.Adresses.Add(adresse);
            _bddContext.SaveChanges();
            return adresse.Id;
        }

        public int CreerAdherent(string nom, string prenom, Adresse adresse, string telephone, string email, string motDePasseConnexion)
        {
            Adherent adherent = new Adherent {Nom = nom, Prenom = prenom, Adresse = adresse, Telephone = telephone, Email = email, MotDePasseConnexion = motDePasseConnexion, DateAdhesion = DateTime.Today, AJour = false };
            _bddContext.Adherents.Add(adherent);
            _bddContext.SaveChanges();
            return adherent.Id;
        }

        public int CreerAdherent(Adherent adherent)
        {
            _bddContext.Adherents.Add(adherent);
            _bddContext.SaveChanges();
            return adherent.Id;
        }
        public void AdherentValidee(int Id)
        {
            Adherent adherentToValidate = _bddContext.Adherents.Find(Id);

            if (adherentToValidate != null)
            {

                adherentToValidate.AJour = true;

                _bddContext.SaveChanges();
            }

        }

        public void ModifierAdherent(int id, string nom, string prenom, Adresse adresseAdh, string telephone, string email, string motDePasseConnexion)
        {
            Adherent adherentAModifier = _bddContext.Adherents.Find(id);

            if (adherentAModifier != null)
            {
                adherentAModifier.Nom = nom;
                adherentAModifier.Prenom = prenom;
                adherentAModifier.Adresse = adresseAdh;
                adherentAModifier.Telephone = telephone;
                adherentAModifier.Email = email;
                adherentAModifier.MotDePasseConnexion = motDePasseConnexion;

                _bddContext.Adherents.Update(adherentAModifier);
                _bddContext.SaveChanges();
            }
        }

        public void ModifierAdherent(Adherent adherent)
        {
            if (adherent != null)
            {
                _bddContext.Adherents.Update(adherent);
                _bddContext.SaveChanges();
            }
        }

        //public int ConnexionAdherent(string email, string motDePasse)
        //{
        //    Adherent adherentAConnecter = _bddContext.Adherents.Find(email);

        //    if (adherentAConnecter != null)
        //    {
        //        return adherentAConnecter.Id;
        //    }
        //    return 
        //}
        //-------------------------------DataProducteur
        public int CreerProducteur(string nomdeferme)
        {
            Producteur producteur = new Producteur { NomFerme = nomdeferme };
            _bddContext.Producteurs.Add(producteur);
            _bddContext.SaveChanges();
            return producteur.Id;
        }

        public List<Producteur> ObtenirTousLesProducteurs()
        {
            return _bddContext.Producteurs.ToList();
        }


        //-------------------------------DataProduits
        // ---------------PRODUIT



        public List<Produit> ObtenirTousLesProduits()
        {
            return _bddContext.Produits.ToList();
        }




        public Produit DetailsProduit(int id)
        {
            Produit produit = _bddContext.Produits.Include(e => e.Producteur).ToList().FirstOrDefault(c => c.Id == id);
            if (produit != null)
            {
                return produit;
            }
            return (null);
        }





        //  ------------------------------PANIER


        public int CreerPanier()
        {
            Panier panier = new Panier() { LignesPanier = new List<LignePanier>() };
            _bddContext.Paniers.Add(panier);
            _bddContext.SaveChanges();
            return panier.Id;
        }


        public Panier ObtenirPanier(int panierId)
        {
            return _bddContext.Paniers.Include(lp => lp.LignesPanier).ThenInclude(p => p.produit).Where(p => p.Id == panierId).FirstOrDefault();
        }



        public void AjouterLigne(int PanierId, LignePanier lignePanier)
        {
            Panier panier = _bddContext.Paniers.Find(PanierId);
            panier.LignesPanier.Add(lignePanier);
            _bddContext.SaveChanges();
        }


        public void UpdateQuantiteLigne(int LignePanierId)
        {
            var lignePanier = _bddContext.LignesPanier.Find(LignePanierId);
            if (lignePanier != null)
            {
                lignePanier.Quantite += 1;
                _bddContext.SaveChanges();
            }
        }

        public void SupprimerLigne(int panierId, int lignePanierId)
        {
            Panier panier = ObtenirPanier(panierId);
            LignePanier lignePanier = panier.LignesPanier.Where(lp => lp.Id == lignePanierId).FirstOrDefault();

            panier.LignesPanier.Remove(lignePanier);
            _bddContext.SaveChanges();
        }
        // ---------------------------------------Paiement 
        public int CreerInfo(int NumeroCb, string Titulaire, string ExpirationCb, int CodeCvc)
        {
            PaiementInfo paiementInfo = new PaiementInfo { NumeroCb = NumeroCb, Titulaire = Titulaire, ExpirationCb = ExpirationCb, CodeCvc = CodeCvc };
            _bddContext.PaiementInfos.Add(paiementInfo);
            _bddContext.SaveChanges();
            return paiementInfo.Id;
        }

        public int CreerInfo(PaiementInfo paiementInfo)
        {
            _bddContext.PaiementInfos.Add(paiementInfo);
            _bddContext.SaveChanges();
            return paiementInfo.Id;

        }

        public void ModifierInfo(int id, int NumeroCb, string Titulaire, string ExpirationCb, int CodeCvc)
        {
            PaiementInfo PaiementInfoToUpdate = _bddContext.PaiementInfos.Find(id);

            if (PaiementInfoToUpdate != null)
            {
                PaiementInfoToUpdate.NumeroCb = NumeroCb;
                PaiementInfoToUpdate.Titulaire = Titulaire;
                PaiementInfoToUpdate.ExpirationCb = ExpirationCb;
                PaiementInfoToUpdate.CodeCvc = CodeCvc;
                _bddContext.SaveChanges();
            }
        }
        // ---------------------------------------Paiement 
        //------------Activité-------------------------
        public List<Activite>ObtientTousLesActivite()
        {
            return _bddContext.Activites.ToList();
        }
        public List<Session> ObtientTousLesSession()
        {
            return _bddContext.Sessions.ToList();
        }

        public int CreerActivite(string titre, int nbreDeParticipants, DateTime date, string lieu, string description, string image, bool valid)
        {
            ImageModel image1 = new ImageModel();
            Activite activite = new Activite
            {
                titre = titre,
                NbreParticipant = nbreDeParticipants,
                Date = date,
                Lieu = lieu,
                Description = description,
                valid = false,
                image = image1.ImageName

            };

            _bddContext.Activites.Add(activite);
            _bddContext.SaveChanges();
            return activite.Id;

        }

        public void CreerActivite(Activite activite)
        {
            if (activite != null)
            {
                _bddContext.Activites.Add(activite);
                _bddContext.SaveChanges();
            }
        }


        public void ModifierActivite(int Id, string titre, int nbreDeParticipants, DateTime date, string lieu, string description)
        {
            Activite activiteToUpdate = _bddContext.Activites.Find(Id);

            if (activiteToUpdate != null)
            {
                activiteToUpdate.titre = titre;
                activiteToUpdate.NbreParticipant = nbreDeParticipants;
                activiteToUpdate.Date = date;
                activiteToUpdate.Lieu = lieu;
                activiteToUpdate.Description = description;
                _bddContext.SaveChanges();
            }

        }
        public void ModifierActivite(Activite activite)
        {
            if (activite != null)
            {
                _bddContext.Activites.Update(activite);
                _bddContext.SaveChanges();
            }
        }

        public void SupprimerActivite(int id)
        {
            Activite activiteToDelete = _bddContext.Activites.Find(id);
            if (activiteToDelete != null)
            {
                _bddContext.Activites.Remove(activiteToDelete);
                _bddContext.SaveChanges();
            }
        }
        public void participer(int id)
        {
            var participants = new List<Adherent>();

            Adherent adherentParticipant = _bddContext.Adherents.Find(id);
            participants.Add(adherentParticipant);


        }
        public void ActiviteValidee(int Id)
        {
            Activite activiteToUpdate = _bddContext.Activites.Find(Id);

            if (activiteToUpdate != null)
            {

                activiteToUpdate.valid = true;

                _bddContext.SaveChanges();
            }

        }


        public int CreerSession(string nom, DateTime date,int nbreAdherentDemende )
        {

            Session session = new Session
            {
                Nom = nom,
                DateSession = date,
                NbreDeBenevoleDemandee = nbreAdherentDemende,

            };


            _bddContext.Sessions.Add(session);
            _bddContext.SaveChanges();
            return session.Id;

        }
        public void CreerSession(Session session)
        {
            if (session != null)
            {
                _bddContext.Sessions.Add(session);
                _bddContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
