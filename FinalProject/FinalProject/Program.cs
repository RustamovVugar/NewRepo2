using FinalProject.Models;
using FinalProject.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pharmacy> pharmacy = new List<Pharmacy>();
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                Helper.Print(ConsoleColor.Yellow, "Yerinə yetrirmək istediyiniz əməliyyat növünün sira nömrəsini daxil edin");
                Helper.Print(ConsoleColor.Green, "1-Aptek yaratmaq,2-Dərman əlavə etmək,3-Satış əməliyyatı, 4- Dərmanların siyahısını göstərmək,5-Axtarış etmək,6-Çıxış.");
                string input = Console.ReadLine();
                bool isInt = int.TryParse(input, out int menu);
                if ((isInt && (menu >= 1 && menu <= 6)))
                {
                    if (menu == 6)
                    {
                        Helper.Print(ConsoleColor.Yellow, "Çıxış");
                        break;
                    }
                    switch (menu)
                    {
                        case 1:

                            Helper.Print(ConsoleColor.Yellow, "Zəhmət olmasa ad daxil edin  ");
                            string pharmacyName = Console.ReadLine();
                            bool isExistPharmacy = pharmacy.Exists(x => x.Name.ToLower() == pharmacyName.ToLower());
                            bool isExistGroup = pharmacy.Exists(x => x.Name.ToLower() == pharmacyName.ToLower());
                            if (isExistGroup)
                            {
                                Helper.Print(ConsoleColor.Red, $"" +
                                    $"Daxil etdiyiniz adda aptek artıq movcuddur");
                                goto case 1;

                            }

                            Pharmacy newPharmacy = new Pharmacy(pharmacyName);
                            pharmacy.Add(newPharmacy);
                            Helper.Print(ConsoleColor.Yellow, $"{newPharmacy.Id}.{pharmacyName} aptek yaradildi");

                            break;
                        case 2:
                            Helper.Print(ConsoleColor.Cyan, "Dərmanı daxil edəcəyiniz aptekin adını mövcud adların siyahısından  secib daxil edin:");
                          a:
                            foreach (Pharmacy anyPharmacy in pharmacy)
                            {
                                Helper.Print(ConsoleColor.Green, anyPharmacy.ToString());
                            }
                            string selectedPharmacy = Console.ReadLine();
                            Pharmacy exsistPharmacy = pharmacy.Find(x => x.Name.ToLower() == selectedPharmacy.ToLower());
                            if (exsistPharmacy == null)
                            {
                                Helper.Print(ConsoleColor.Red, $"{selectedPharmacy} apteki yoxdur.");
                                goto a;
                            }
                            Helper.Print(ConsoleColor.Cyan, "Zəhmət olmasa daxil etmək istədiyiniz dərman adını daxil edin:");
                            string name = Console.ReadLine();
                            Helper.Print(ConsoleColor.Cyan, "Dərman vasitəsinin hansı növ dərman vasitəsinə   " +
                                "aid olduğunu qeyd edin!");
                            string drugType = Console.ReadLine();
                           b:
                            Helper.Print(ConsoleColor.Cyan, "Dərmanın qiymətini daxil edin:"); input = Console.ReadLine();
                            isInt = int.TryParse(input, out int price);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Dərmanın qiyməti rəqəmlə daxil edilməlidir:");
                                goto b;
                            }
                          c:
                            Helper.Print(ConsoleColor.Green, "Dərmanın sayını daxil edin:");
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int count);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Zəhmət olmasa ədəd daxil edin:");
                                goto c;

                            }
                            Drug newDrug = new Drug(name, price, count);
                            exsistPharmacy.AddDrug(newDrug);
                            Helper.Print(ConsoleColor.Green, $"{newDrug.Id } {newDrug.Name} {newDrug.Count}sayda {newDrug.Price} tipli dərman {exsistPharmacy} " +
                                $"aptekinə əlavə olundu");


                            break;
                        case 3:
                            Helper.Print(ConsoleColor.DarkMagenta, "Dərmanı satın almaq istədiyiniz aptekin adını mövcud siyahıdan  secib daxil edin:");
                        d:
                            foreach (Pharmacy anyPharmacy in pharmacy)
                            {
                                Helper.Print(ConsoleColor.Green, anyPharmacy.ToString());
                            }
                            string searchedPharmacy = Console.ReadLine();
                            Pharmacy isExsist = pharmacy.Find(x => x.Name.ToLower() == searchedPharmacy.ToLower());
                            if (isExsist == null)
                            {
                                Helper.Print(ConsoleColor.Red, $"{searchedPharmacy } apteki yoxdur.");
                                goto d;
                            }

                            Helper.Print(ConsoleColor.Cyan, "Dərmanın adını daxil edin:");
                            string drugName = Console.ReadLine();
                        e:
                            Helper.Print(ConsoleColor.Cyan, "Dərmanın qiymətini daxil edin:");
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int drugPrice);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Dərmanın qiyməti rəqəmlə daxil edilməlidir:");
                                goto e;
                            }
                        f:
                            Helper.Print(ConsoleColor.Cyan, "Dərman sayını daxil edin:");
                            input = Console.ReadLine();
                            isInt = int.TryParse(input, out int drugCount);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Ədəd daxil edin:");
                                goto f;
                            }
                            Pharmacy aPharmacy = new Pharmacy();
                            aPharmacy.SaleDrug(drugName, drugCount, drugPrice);

                            break;
                        case 4:
                        g:
                            Helper.Print(ConsoleColor.Blue, "Aptek adlarından isteyinizə uygun aptek " +
                                "adını daxil edin");
                            foreach (var item in pharmacy)
                            {
                                Helper.Print(ConsoleColor.Green, item.ToString());
                            }
                            string wantedPharmacyName = Console.ReadLine();
                            Pharmacy expectedPharmacy = pharmacy.Find(x => x.Name.ToLower() == wantedPharmacyName.ToLower());
                            if (expectedPharmacy == null)
                            {
                                Helper.Print(ConsoleColor.Red, $"{wantedPharmacyName} apteki yoxdur.");
                                goto g;
                            }
                            Helper.Print(ConsoleColor.Cyan, $"{wantedPharmacyName} aptekində olan dərmanların siyahısı;");
                            expectedPharmacy.ShowDrugItems();

                            break;

                        case 5:
                            Helper.Print(ConsoleColor.DarkGreen, "Axtardığınız dərmanın adını daxil edin:");
                            string searchedDrugName = Console.ReadLine();
                            foreach (Pharmacy searchdPharmacy in pharmacy)
                            {
                                List<Drug> foundedDrug = searchdPharmacy.InfoDrug(searchedDrugName);

                                foreach (Drug drug in foundedDrug)
                                {
                                    Helper.Print(ConsoleColor.Cyan, $"{drug.ToString()} dərmanı {searchdPharmacy} aptekində mövcuddur");
                                }

                            }

                            break;
                        Default:
                            break;

                    }
                    }
                else
                    {
                        Helper.Print(ConsoleColor.Red, "Seçiminiz düzgün deyil.Xahiş edirik ekranda gördüyünüz əməliyyat nömrələrindən birini seçəsiniz!");
                    }

                }
            }
        }
    }

                
