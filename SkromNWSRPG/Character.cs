using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkromNWSRPG
{
    /*
     * Cette classe représente un Personnage dans le Jeu
     *
     * Elle possède un Name
     * Elle possède une valeur de Life
     *
     * Cette Classe possède une Méthode Equip
     * Elle prend en paramètre un équipement et l'applique au slot correspondant du Character
     *
     * Le Character peut porter une arme dans les deux mains, à condition que ce soit un Weapon
     * Un objet à deux mains bloque l'emplacement OffHand et Weapon
     *
     * équiper un objet à une main 2 fois de suite dans Weapon l'équipe dans Weapon & OffHand
     *
     *
     * Cette Classe possède une Methode GetItemInSlot
     * Elle prend en paramètre un GearSlot
     * Elle renvoie l'objet équipé à l'emplacement passé en paramètre
     * Elle renvoie null si il n'y a rien à cet emplacement
     */
    public class Character
    {
        public string Name;
        public int Life = 100;
        public Dictionary<GearSlot, Gear> Inventory = new Dictionary<GearSlot, Gear>();
        public bool flag = false;


        public Character(string name, int life)
        {
            Name = name;
            Life = life;
        }

        public void Equip(Gear equipment)
        {

            switch (equipment.Slot)
            {
                case GearSlot.TwoHand:
                    Inventory[GearSlot.Weapon] = equipment;
                    Inventory[GearSlot.OffHand] = null;
                    break;

                case GearSlot.Weapon:
                    if (this.flag == true)
                    {
                        Inventory[GearSlot.OffHand] = equipment;
                        this.flag = false;
                    }
                    else
                    {
                        Inventory[GearSlot.Weapon] = equipment;
                        this.flag = true;
                    }
                    Inventory[GearSlot.TwoHand] = null;
                    break;

                case GearSlot.OffHand:
                    Inventory[GearSlot.OffHand] = equipment;
                    Inventory[GearSlot.Weapon] = null;
                    break;

                case GearSlot.Head:
                    Inventory[GearSlot.Head] = equipment;
                    break;

                case GearSlot.Back:
                    Inventory[GearSlot.Back] = equipment;
                    break;

                case GearSlot.Chest:
                    Inventory[GearSlot.Chest] = equipment;
                    break;

                case GearSlot.Legs:
                    Inventory[GearSlot.Legs] = equipment;
                    break;

                case GearSlot.Feet:
                    Inventory[GearSlot.Feet] = equipment;
                    break;

                default:
                    Console.WriteLine("Erreur, ce n'est pas une arme ou armure");
                    break;
            }
        }

        public Gear GetItemInSlot(GearSlot slot)
        {
            if (Inventory[slot] != null)
            {
                return Inventory[slot];
            }
            else
            {
                return null;
            }
        }

        public void CleanInventory()
        {

        }
    }
}
