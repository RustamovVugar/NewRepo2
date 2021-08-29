using FinalProject.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Models
{
    class Pharmacy
    {
        public string Name { get; set; }
        public int Id { get; }
        private static int _id = 0;
        private List<Drug> _drugs;
        public Pharmacy()
        {
            _id++;
            Id = _id;
            _drugs = new List<Drug>();
        }
        public Pharmacy(string name):this()
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{Id}-{Name}";
        }
        public void AddDrug(Drug drug)
        {
            bool isFalse = false;
            foreach (Drug addedDrug in _drugs)
            {

                if (addedDrug.Name == drug.Name)
                {
                    addedDrug.Count += drug.Count;
                    isFalse = true;
                }

            }
            if (isFalse == false)
            {
                _drugs.Add(drug);
            }
        }
        public List<Drug> InfoDrug(string name)
        {
            List<Drug> searchedDrug = _drugs.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
            return searchedDrug;
        }
        public void ShowDrugItems()
        {
            if(_drugs.Count == 0)
            {
                return;
            }
            foreach (Drug drug in _drugs)
            {
                Helper.Print(ConsoleColor.Blue, drug.ToString());
            }
        }
        public void SaleDrug(string drugName,double drugPrice,int drugCount)
        {
            Drug exitDrug = new Drug();
            foreach (Drug exisistDrug in _drugs)
            {
                if (exisistDrug.Name.ToLower() == drugName.ToLower())
                {
                    exitDrug = exisistDrug;
                    break;
                }
            }
            if (exitDrug.Name.ToLower() == drugName.ToLower())
            {
                if (exitDrug.Count >= drugCount)
                {
                    if ((drugCount * exitDrug.Price) <= drugPrice)
                    {
                        exitDrug.Count -= drugCount;
                        Helper.Print(ConsoleColor.Gray, $"Satış ugurla baş verdi: Pul qalığınızı: {drugPrice - exitDrug.Price * drugCount}" +
                            $"qədər  çatmır");

                    }
                }
            }
        

    }
}
