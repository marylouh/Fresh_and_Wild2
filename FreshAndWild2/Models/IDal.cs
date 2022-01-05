using System;
using System.Collections.Generic;

namespace FreshAndWild2.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();

        List<Utilisateur> ObtenirTousLesUtilisateurs();

        List<Adherent> ObtenirTousLesAdherents();

        //int CreerSejour(string lieu, string telephone);
        //void ModifierSejour(int id, string lieu, string telephone);
        List<PaiementInfo> ObtenirTousLesPaiementsInfo();
        int CreerInfo(PaiementInfo paiementInfo);

        int CreerInfo(int NumeroCb, string Titulaire, string ExpirationCb, int CodeCvc);

        void ModifierInfo(int id, int NumeroCb, string Titulaire, string ExpirationCb, int CodeCvc);
        //------------Activité-------------------------
        List<Activite> ObtientTousLesActivite();
        int CreerActivite(string titre, int nbreDeParticipants, DateTime date, string lieu, string description, string image, bool valid);
        void ModifierActivite(int Id, string titre, int nbreDeParticipants, DateTime date, string lieu, string description);
        //------------Activité-------------------------
    }
}
