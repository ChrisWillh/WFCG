using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarhammerFantasyCharGen
{
    public partial class WarhammerFantasyCharGen : Form
    {
        int marked = 0;
        int startingGold = 0;
        int careerGold = 0;
        string rSkill1 = "Speak Language (Reikspiel)"
            , rSkill2 = ""
            , rSkill3 = ""
            , rSkill4 = ""
            , rSkill5 = ""
            , rSkill6 = ""
            , rTallent1 = ""
            , rTallent2 = ""
            , rTallent3 = ""
            , rTallent4 = ""
            , rTallent5 = ""
            , rTallent6 = "";
        string[] careers = {"Agitator",
                                "Apprentice Wizard",
                                "Bailiff",
                                "Barber-Surgeon",
                                "Boatman",
                                "Bodyguard",
                                "Bone Picker",
                                "Bounty Hunter",
                                "Burgher",
                                "Camp Follower",
                                "Charcoal-Burner",
                                "Coachman",
                                "Entertainer",
                                "Envoy",
                                "Estalian Diestro",
                                "Ferryman",
                                "Fieldwarden",
                                "Fisherman",
                                "Grave Robber",
                                "Hedge Wizard",
                                "Hunter",
                                "Initiate",
                                "Jailer",
                                "Kislevite Kossar",
                                "Kithband Warrior",
                                "Marine",
                                "Mercenary",
                                "Messenger",
                                "Militiaman",
                                "Miner",
                                "Noble",
                                "Norse Berserker",
                                "Outlaw",
                                "Outrider",
                                "Peasant",
                                "Pit Fighter",
                                "Protagonist",
                                "Rat Catcher",
                                "Roadwarden",
                                "Rogue",
                                "Runebearer",
                                "Scribe",
                                "Seaman",
                                "Servant",
                                "Shieldbreaker",
                                "Smuggler",
                                "Soldier",
                                "Squire",
                                "Student",
                                "Thief",
                                "Thug",
                                "Toll Keeper",
                                "Tomb Robber",
                                "Traidsman",
                                "Troll Slayer",
                                "Vagabond",
                                "Valet",
                                "Watchman",
                                "Woodsman",
                                "Zealot"};

        string[] hairColors = {"Ash Blond",
                                   "Corn",
                                   "Yellow",
                                   "Copper",
                                   "Red",
                                   "Light Brown",
                                   "Brown",
                                   "Dark Brown",
                                   "Black",
                                   "Blue Black",
                                   "Silver"};

        string[] eyeColors = {"Pale Grey",
                                  "Grey Blue",
                                  "Blue",
                                  "Green",
                                  "Copper",
                                  "Light Brown",
                                  "Brown",
                                  "Dark Brown",
                                  "Purple",
                                  "Black",
                                  "Silver",
                                  "Hazel"};

        public WarhammerFantasyCharGen()
        {
            InitializeComponent();

            characterGen();
        }

        public void characterGen()
        {
            int elf = 0;
            var r = new Random();

            if (cbRace.SelectedIndex == 1)
            { elf = 1; }
            else { elf = 0; }

            //Load race based lists
            loadRace();
            raceSkills();
            
            //roll stats
            statsRoll();

            //Pick Career
            careerRoll();
            
            //pick eye color
            eyeColorRoll();
            
            //pick hair color
            hairColorRoll();
            
            //pick weight
            weightRoll();
            
            //pick Height
            heightRoll();

            //roll for distinguishing mark
            markRoll(elf);

            //Roll for number of siblings
            siblingsRoll();

            //roll for age
            ageRoll();

            //roll for star sign
            signRoll();

            //roll for birthplace
            birthRoll();

            //Career equipment
            careerChanged();

            //roll for starting gold
            startingGold = r.Next(2, 20);
            txGold.Text = Convert.ToString(startingGold + careerGold);
        }

        public void loadRace()
        {
            cbCareer.Items.Clear();
            cbEyeColor.Items.Clear();
            cbHairColor.Items.Clear();

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    cbCareer.Items.AddRange(new object[] {
                    careers[0],
                    careers[5],
                    careers[8],
                    careers[11],
                    careers[12],
                    careers[20],
                    careers[22],
                    careers[25],
                    careers[26],
                    careers[28],
                    careers[29],
                    careers[30],
                    careers[32],
                    careers[35],
                    careers[36],
                    careers[37],
                    careers[40],
                    careers[41],
                    careers[42],
                    careers[43],
                    careers[44],
                    careers[45],
                    careers[46],
                    careers[48],
                    careers[49],
                    careers[51],
                    careers[52],
                    careers[53],
                    careers[54],
                    careers[57]});

                    cbEyeColor.Items.AddRange(new object[] {
                    eyeColors[0],
                    eyeColors[2],
                    eyeColors[4],
                    eyeColors[5],
                    eyeColors[6],
                    eyeColors[7],
                    eyeColors[8]});

                    cbHairColor.Items.AddRange(new object[] {
                    hairColors[0],
                    hairColors[2],
                    hairColors[4],
                    hairColors[3],
                    hairColors[5],
                    hairColors[6],
                    hairColors[7],
                    hairColors[9],
                    hairColors[8]}); 
                    break;
                case 1:
                    cbEyeColor.Items.AddRange(new object[] {
                    eyeColors[1],
                    eyeColors[2],
                    eyeColors[3],
                    eyeColors[4],
                    eyeColors[5],
                    eyeColors[6],
                    eyeColors[7],
                    eyeColors[10],
                    eyeColors[8],
                    eyeColors[9]});
                    
                    cbHairColor.Items.AddRange(new object[] {
                    hairColors[10],
                    hairColors[0],
                    hairColors[1],
                    hairColors[2],
                    hairColors[3],
                    hairColors[5],
                    hairColors[6],
                    hairColors[7],
                    hairColors[8]});

                    cbCareer.Items.AddRange(new object[] {
                    careers[1],
                    careers[12],
                    careers[13],
                    careers[20],
                    careers[24],
                    careers[26],
                    careers[27],
                    careers[32],
                    careers[33],
                    careers[39],
                    careers[41],
                    careers[42],
                    careers[48],
                    careers[49],
                    careers[53],
                    careers[55]});
                    break;
                case 2:
                    cbEyeColor.Items.AddRange(new object[] {
                    eyeColors[2],
                    eyeColors[11],
                    eyeColors[5],
                    eyeColors[6],
                    eyeColors[7]});
                    
                    cbHairColor.Items.AddRange(new object[] {
                    hairColors[0],
                    hairColors[1],
                    hairColors[2],
                    hairColors[3],
                    hairColors[4],
                    hairColors[5],
                    hairColors[6],
                    hairColors[7],
                    hairColors[8]});

                    cbCareer.Items.AddRange(new object[] {
                    careers[0],
                    careers[3],
                    careers[6],
                    careers[7],
                    careers[8],
                    careers[9],
                    careers[10],
                    careers[12],
                    careers[15],
                    careers[16],
                    careers[17],
                    careers[18],
                    careers[20],
                    careers[26],
                    careers[27],
                    careers[28],
                    careers[32],
                    careers[34],
                    careers[37],
                    careers[39],
                    careers[43],
                    careers[45],
                    careers[46],
                    careers[48],
                    careers[49],
                    careers[51],
                    careers[52],
                    careers[53],
                    careers[55],
                    careers[56],
                    careers[57]});
                    break;
                case 3:
                    cbEyeColor.Items.AddRange(new object[] {
                    eyeColors[0],
                    eyeColors[1],
                    eyeColors[2],
                    eyeColors[3],
                    eyeColors[4],
                    eyeColors[5],
                    eyeColors[6],
                    eyeColors[7],
                    eyeColors[8],
                    eyeColors[9]});

                    cbHairColor.Items.AddRange(new object[] {
                    hairColors[0],
                    hairColors[1],
                    hairColors[2],
                    hairColors[3],
                    hairColors[4],
                    hairColors[5],
                    hairColors[6],
                    hairColors[7],
                    hairColors[8]});

                    cbCareer.Items.AddRange(new object[] {
                    careers[0],
                    careers[1],
                    careers[2],
                    careers[3],
                    careers[4],
                    careers[5],
                    careers[6],
                    careers[7],
                    careers[8],
                    careers[9],
                    careers[10],
                    careers[11],
                    careers[12],
                    careers[14],
                    careers[15],
                    careers[17],
                    careers[18],
                    careers[19],
                    careers[20],
                    careers[21],
                    careers[22],
                    careers[23],
                    careers[25],
                    careers[26],
                    careers[27],
                    careers[28],
                    careers[29],
                    careers[30],
                    careers[31],
                    careers[32],
                    careers[33],
                    careers[34],
                    careers[35],
                    careers[36],
                    careers[37],
                    careers[38],
                    careers[39],
                    careers[41],
                    careers[42],
                    careers[43],
                    careers[45],
                    careers[46],
                    careers[47],
                    careers[48],
                    careers[49],
                    careers[50],
                    careers[51],
                    careers[52],
                    careers[53],
                    careers[55],
                    careers[56],
                    careers[57],
                    careers[58],
                    careers[59]});
                    break;
            }
        }

        public void statsRoll()
        {
            var r = new Random();
            int woundsRoll = r.Next(1, 10);
            int fateRoll = r.Next(1, 10);
            int WSBase = 20;
            int BSBase = 20;
            int SBase = 20;
            int TBase = 20;
            int AgBase = 20;
            int IntBase = 20;
            int WPBase = 20;
            int FelBase = 20;
            int wound1 = 10;
            int wound2 = 10;
            int wound3 = 10;
            int wound4 = 10;
            int fate1 = 1;
            int fate2 = 1;
            int fate3 = 1;

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    WSBase = 30;
                    BSBase = 20;
                    SBase = 20;
                    TBase = 30;
                    AgBase = 10;
                    IntBase = 20;
                    WPBase = 20;
                    FelBase = 10;
                    wound1 = 11;
                    wound2 = 12;
                    wound3 = 13;
                    wound4 = 14;
                    fate1 = 1;
                    fate2 = 2;
                    fate3 = 3;
                    break;
                case 1:
                    WSBase = 20;
                    BSBase = 30;
                    SBase = 20;
                    TBase = 20;
                    AgBase = 30;
                    IntBase = 20;
                    WPBase = 20;
                    FelBase = 20;
                    wound1 = 9;
                    wound2 = 10;
                    wound3 = 11;
                    wound4 = 12;
                    fate1 = 1;
                    fate2 = 2;
                    fate3 = 2;
                    break;
                case 2:
                    WSBase = 10;
                    BSBase = 30;
                    SBase = 10;
                    TBase = 10;
                    AgBase = 30;
                    IntBase = 20;
                    WPBase = 20;
                    FelBase = 30;
                    wound1 = 8;
                    wound2 = 9;
                    wound3 = 10;
                    wound4 = 11;
                    fate1 = 2;
                    fate2 = 2;
                    fate3 = 3;
                    break;
                case 3:
                    WSBase = 20;
                    BSBase = 20;
                    SBase = 20;
                    TBase = 20;
                    AgBase = 20;
                    IntBase = 20;
                    WPBase = 20;
                    FelBase = 20;
                    wound1 = 10;
                    wound2 = 11;
                    wound3 = 12;
                    wound4 = 13;
                    fate1 = 2;
                    fate2 = 3;
                    fate3 = 3;
                    break;
            }

            txWeaponSkilStart.Text = Convert.ToString(WSBase + r.Next(2, 20));
            txBalisticSkilStart.Text = Convert.ToString(BSBase + r.Next(2, 20));
            txStrentghStart.Text = Convert.ToString(SBase + r.Next(2, 20));
            txToughnesStart.Text = Convert.ToString(TBase + r.Next(2, 20));
            txAgilityStart.Text = Convert.ToString(AgBase + r.Next(2, 20));
            txIntStart.Text = Convert.ToString(IntBase + r.Next(2, 20));
            txWillStart.Text = Convert.ToString(WPBase + r.Next(2, 20));
            txFellowStart.Text = Convert.ToString(FelBase + r.Next(2, 20));

            switch (r.Next(1, 10))
            {
                case 1:
                case 2:
                case 3:
                    txWoundsStart.Text = Convert.ToString(wound1);
                    break;
                case 4:
                case 5:
                case 6:
                    txWoundsStart.Text = Convert.ToString(wound2);
                    break;
                case 7:
                case 8:
                case 9:
                    txWoundsStart.Text = Convert.ToString(wound3);
                    break;
                case 10:
                    txWoundsStart.Text = Convert.ToString(wound4);
                    break;
            }

            txStrBonusStart.Text = Convert.ToString(Convert.ToInt32(txStrentghStart.Text) / 10);
            txToughBonusStart.Text = Convert.ToString(Convert.ToInt32(txToughnesStart.Text) / 10);

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    txMoveStart.Text = "3";
                    break;
                case 1:
                    txMoveStart.Text = "5";
                    break;
                case 2:
                    txMoveStart.Text = "4";
                    break;
                case 3:
                    txMoveStart.Text = "4";
                    break;
            }

            switch (r.Next(1, 10))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    txFateStart.Text = Convert.ToString(fate1);
                    break;
                case 5:
                case 6:
                case 7:
                    txFateStart.Text = Convert.ToString(fate2);
                    break;
                case 8:
                case 9:
                case 10:
                    txFateStart.Text = Convert.ToString(fate3);
                    break;
            }
        }

        public void careerRoll()
        {
            var r = new Random();
            int careerPick = r.Next(1, 100);

            switch(cbRace.SelectedIndex)
            {
                case 0:
                    if (careerPick >= 1 && careerPick <= 2)
                    { cbCareer.SelectedIndex = 0; }
                    else if (careerPick >= 3 && careerPick <= 6)
                    { cbCareer.SelectedIndex = 1; }
                    else if (careerPick >= 7 && careerPick <= 10)
                    { cbCareer.SelectedIndex = 2; }
                    else if (careerPick >= 11 && careerPick <= 12)
                    { cbCareer.SelectedIndex = 3; }
                    else if (careerPick >= 13 && careerPick <= 15)
                    { cbCareer.SelectedIndex = 4; }
                    else if (careerPick >= 16 && careerPick <= 19)
                    { cbCareer.SelectedIndex = 5; }
                    else if (careerPick >= 20 && careerPick <= 23)
                    { cbCareer.SelectedIndex = 6; }
                    else if (careerPick == 24)
                    { cbCareer.SelectedIndex = 7; }
                    else if (careerPick >= 25 && careerPick <= 30)
                    { cbCareer.SelectedIndex = 8; }
                    else if (careerPick >= 31 && careerPick <= 34)
                    { cbCareer.SelectedIndex = 9; }
                    else if (careerPick >= 35 && careerPick <= 40)
                    { cbCareer.SelectedIndex = 10; }
                    else if (careerPick >= 41 && careerPick <= 42)
                    { cbCareer.SelectedIndex = 11; }
                    else if (careerPick >= 43 && careerPick <= 45)
                    { cbCareer.SelectedIndex = 12; }
                    else if (careerPick >= 46 && careerPick <= 50)
                    { cbCareer.SelectedIndex = 13; }
                    else if (careerPick >= 51 && careerPick <= 54)
                    { cbCareer.SelectedIndex = 14; }
                    else if (careerPick >= 55 && careerPick <= 58)
                    { cbCareer.SelectedIndex = 15; }
                    else if (careerPick >= 59 && careerPick <= 63)
                    { cbCareer.SelectedIndex = 16; }
                    else if (careerPick >= 64 && careerPick <= 65)
                    { cbCareer.SelectedIndex = 17; }
                    else if (careerPick == 66)
                    { cbCareer.SelectedIndex = 18; }
                    else if (careerPick >= 67 && careerPick <= 68)
                    { cbCareer.SelectedIndex = 19; }
                    else if (careerPick >= 69 && careerPick <= 72)
                    { cbCareer.SelectedIndex = 20; }
                    else if (careerPick >= 73 && careerPick <= 75)
                    { cbCareer.SelectedIndex = 21; }
                    else if (careerPick >= 76 && careerPick <= 79)
                    { cbCareer.SelectedIndex = 22; }
                    else if (careerPick >= 80 && careerPick <= 81)
                    { cbCareer.SelectedIndex = 23; }
                    else if (careerPick >= 82 && careerPick <= 84)
                    { cbCareer.SelectedIndex = 24; }
                    else if (careerPick >= 85 && careerPick <= 87)
                    { cbCareer.SelectedIndex = 25; }
                    else if (careerPick >= 88 && careerPick <= 90)
                    { cbCareer.SelectedIndex = 26; }
                    else if (careerPick >= 91 && careerPick <= 94)
                    { cbCareer.SelectedIndex = 27; }
                    else if (careerPick >= 95 && careerPick <= 98)
                    { cbCareer.SelectedIndex = 28; }
                    else if (careerPick >= 99 && careerPick <= 100)
                    { cbCareer.SelectedIndex = 29; }
                    break;
                case 1:
                    if (careerPick >= 1 && careerPick <= 7)
                    { cbCareer.SelectedIndex = 0; }
                    else if (careerPick >= 8 && careerPick <= 12)
                    { cbCareer.SelectedIndex = 1; }
                    else if (careerPick >= 13 && careerPick <= 19)
                    { cbCareer.SelectedIndex = 2; }
                    else if (careerPick >= 20 && careerPick <= 27)
                    { cbCareer.SelectedIndex = 3; }
                    else if (careerPick >= 28 && careerPick <= 34)
                    { cbCareer.SelectedIndex = 4; }
                    else if (careerPick >= 35 && careerPick <= 39)
                    { cbCareer.SelectedIndex = 5; }
                    else if (careerPick >= 40 && careerPick <= 45)
                    { cbCareer.SelectedIndex = 6; }
                    else if (careerPick >= 46 && careerPick <= 51)
                    { cbCareer.SelectedIndex = 7; }
                    else if (careerPick >= 52 && careerPick <= 57)
                    { cbCareer.SelectedIndex = 8; }
                    else if (careerPick >= 58 && careerPick <= 63)
                    { cbCareer.SelectedIndex = 9; }
                    else if (careerPick >= 64 && careerPick <= 69)
                    { cbCareer.SelectedIndex = 10; }
                    else if (careerPick >= 70 && careerPick <= 75)
                    { cbCareer.SelectedIndex = 11; }
                    else if (careerPick >= 76 && careerPick <= 80)
                    { cbCareer.SelectedIndex = 12; }
                    else if (careerPick >= 81 && careerPick <= 86)
                    { cbCareer.SelectedIndex = 13; }
                    else if (careerPick >= 87 && careerPick <= 93)
                    { cbCareer.SelectedIndex = 14; }
                    else if (careerPick >= 94 && careerPick <= 100)
                    { cbCareer.SelectedIndex = 15; }
                    break;
                case 2:
                    if (careerPick >= 1 && careerPick <= 3)
                    { cbCareer.SelectedIndex = 0; }
                    else if (careerPick == 4)
                    { cbCareer.SelectedIndex = 1; }
                    else if (careerPick == 5)
                    { cbCareer.SelectedIndex = 2; }
                    else if (careerPick >= 6 && careerPick <= 7)
                    { cbCareer.SelectedIndex = 3; }
                    else if (careerPick >= 8 && careerPick <= 9)
                    { cbCareer.SelectedIndex = 4; }
                    else if (careerPick >= 10 && careerPick <= 11)
                    { cbCareer.SelectedIndex = 5; }
                    else if (careerPick >= 12 && careerPick <= 14)
                    { cbCareer.SelectedIndex = 6; }
                    else if (careerPick >= 15&& careerPick <= 17)
                    { cbCareer.SelectedIndex = 7; }
                    else if (careerPick == 18)
                    { cbCareer.SelectedIndex = 8; }
                    else if (careerPick >= 19&& careerPick <= 22)
                    { cbCareer.SelectedIndex = 9; }
                    else if (careerPick == 23)
                    { cbCareer.SelectedIndex = 10; }
                    else if (careerPick >= 24&& careerPick <= 26)
                    { cbCareer.SelectedIndex = 11; }
                    else if (careerPick >= 27&& careerPick <= 31)
                    { cbCareer.SelectedIndex = 12; }
                    else if (careerPick >= 32&& careerPick <= 35)
                    { cbCareer.SelectedIndex = 13; }
                    else if (careerPick >= 36&& careerPick <= 40)
                    { cbCareer.SelectedIndex = 14; }
                    else if (careerPick >= 41&& careerPick <= 45)
                    { cbCareer.SelectedIndex = 15; }
                    else if (careerPick >= 46&& careerPick <= 48)
                    { cbCareer.SelectedIndex = 16; }
                    else if (careerPick >= 49&& careerPick <= 54)
                    { cbCareer.SelectedIndex = 17; }
                    else if (careerPick == 55)
                    { cbCareer.SelectedIndex = 18; }
                    else if (careerPick >= 56&& careerPick <= 60)
                    { cbCareer.SelectedIndex = 19; }
                    else if (careerPick >= 61&& careerPick <= 65)
                    { cbCareer.SelectedIndex = 20; }
                    else if (careerPick >= 66&& careerPick <= 68)
                    { cbCareer.SelectedIndex = 21; }
                    else if (careerPick >= 69&& careerPick <= 70)
                    { cbCareer.SelectedIndex = 22; }
                    else if (careerPick >= 71&& careerPick <= 72)
                    { cbCareer.SelectedIndex = 23; }
                    else if (careerPick >= 73&& careerPick <= 78)
                    { cbCareer.SelectedIndex = 24; }
                    else if (careerPick >= 79&& careerPick <= 80)
                    { cbCareer.SelectedIndex = 25; }
                    else if (careerPick >= 81&& careerPick <= 85)
                    { cbCareer.SelectedIndex = 26; }
                    else if (careerPick >= 86&& careerPick <= 90)
                    { cbCareer.SelectedIndex = 27; }
                    else if (careerPick >= 91&& careerPick <= 94)
                    { cbCareer.SelectedIndex = 28; }
                    else if (careerPick >= 95&& careerPick <= 96)
                    { cbCareer.SelectedIndex = 29; }
                    else if (careerPick >= 97&& careerPick <= 100)
                    { cbCareer.SelectedIndex = 30; }
                    break;
                case 3:
                    if (careerPick >= 1 && careerPick <= 2)
                    { cbCareer.SelectedIndex = 0; }
                    else if (careerPick >= 3 && careerPick <= 4)
                    { cbCareer.SelectedIndex = 1; }
                    else if (careerPick == 5)
                    { cbCareer.SelectedIndex = 2; }
                    else if (careerPick == 6)
                    { cbCareer.SelectedIndex = 3; }
                    else if (careerPick >= 7 && careerPick <= 8)
                    { cbCareer.SelectedIndex = 4; }
                    else if (careerPick >= 9 && careerPick <= 10)
                    { cbCareer.SelectedIndex = 5; }
                    else if (careerPick >= 11 && careerPick <= 12)
                    { cbCareer.SelectedIndex = 6; }
                    else if (careerPick >= 13 && careerPick <= 14)
                    { cbCareer.SelectedIndex = 7; }
                    else if (careerPick >= 15 && careerPick <= 16)
                    { cbCareer.SelectedIndex = 8; }
                    else if (careerPick >= 17 && careerPick <= 18)
                    { cbCareer.SelectedIndex = 9; }
                    else if (careerPick >= 19 && careerPick <= 20)
                    { cbCareer.SelectedIndex = 10; }
                    else if (careerPick >= 21 && careerPick <= 22)
                    { cbCareer.SelectedIndex = 11; }
                    else if (careerPick >= 22 && careerPick <= 24)
                    { cbCareer.SelectedIndex = 12; }
                    else if (careerPick == 25)
                    { cbCareer.SelectedIndex = 13; }
                    else if (careerPick == 26)
                    { cbCareer.SelectedIndex = 14; }
                    else if (careerPick >= 27 && careerPick <= 28)
                    { cbCareer.SelectedIndex = 15; }
                    else if (careerPick >= 29 && careerPick <= 30)
                    { cbCareer.SelectedIndex = 16; }
                    else if (careerPick == 31)
                    { cbCareer.SelectedIndex = 17; }
                    else if (careerPick >= 32 && careerPick <= 33)
                    { cbCareer.SelectedIndex = 18; }
                    else if (careerPick >= 34 && careerPick <= 35)
                    { cbCareer.SelectedIndex = 19; }
                    else if (careerPick == 36)
                    { cbCareer.SelectedIndex = 20; }
                    else if (careerPick == 37)
                    { cbCareer.SelectedIndex = 21; }
                    else if (careerPick >= 38 && careerPick <= 39)
                    { cbCareer.SelectedIndex = 22; }
                    else if (careerPick >= 40 && careerPick <= 41)
                    { cbCareer.SelectedIndex = 23; }
                    else if (careerPick >= 42 && careerPick <= 43)
                    { cbCareer.SelectedIndex = 24; }
                    else if (careerPick >= 44 && careerPick <= 45)
                    { cbCareer.SelectedIndex = 25; }
                    else if (careerPick >= 46 && careerPick <= 47)
                    { cbCareer.SelectedIndex = 26; }
                    else if (careerPick >= 48 && careerPick <= 49)
                    { cbCareer.SelectedIndex = 27; }
                    else if (careerPick == 50)
                    { cbCareer.SelectedIndex = 28; }
                    else if (careerPick >= 51 && careerPick <= 52)
                    { cbCareer.SelectedIndex = 29; }
                    else if (careerPick >= 53 && careerPick <= 54)
                    { cbCareer.SelectedIndex = 30; }
                    else if (careerPick >= 55 && careerPick <= 56)
                    { cbCareer.SelectedIndex = 31; }
                    else if (careerPick >= 57 && careerPick <= 58)
                    { cbCareer.SelectedIndex = 32; }
                    else if (careerPick >= 59 && careerPick <= 60)
                    { cbCareer.SelectedIndex = 33; }
                    else if (careerPick >= 61 && careerPick <= 62)
                    { cbCareer.SelectedIndex = 34; }
                    else if (careerPick >= 63 && careerPick <= 64)
                    { cbCareer.SelectedIndex = 35; }
                    else if (careerPick >= 65 && careerPick <= 66)
                    { cbCareer.SelectedIndex = 36; }
                    else if (careerPick >= 67 && careerPick <= 68)
                    { cbCareer.SelectedIndex = 37; }
                    else if (careerPick >= 69 && careerPick <= 70)
                    { cbCareer.SelectedIndex = 38; }
                    else if (careerPick >= 71 && careerPick <= 72)
                    { cbCareer.SelectedIndex = 39; }
                    else if (careerPick >= 73 && careerPick <= 74)
                    { cbCareer.SelectedIndex = 40; }
                    else if (careerPick >= 75 && careerPick <= 76)
                    { cbCareer.SelectedIndex = 41; }
                    else if (careerPick >= 77 && careerPick <= 78)
                    { cbCareer.SelectedIndex = 42; }
                    else if (careerPick >= 79 && careerPick <= 80)
                    { cbCareer.SelectedIndex = 43; }
                    else if (careerPick >= 81 && careerPick <= 82)
                    { cbCareer.SelectedIndex = 44; }
                    else if (careerPick >= 83 && careerPick <= 84)
                    { cbCareer.SelectedIndex = 45; }
                    else if (careerPick >= 85 && careerPick <= 86)
                    { cbCareer.SelectedIndex = 46; }
                    else if (careerPick >= 87 && careerPick <= 88)
                    { cbCareer.SelectedIndex = 47; }
                    else if (careerPick >= 89 && careerPick <= 90)
                    { cbCareer.SelectedIndex = 48; }
                    else if (careerPick >= 91 && careerPick <= 92)
                    { cbCareer.SelectedIndex = 49; }
                    else if (careerPick >= 93 && careerPick <= 94)
                    { cbCareer.SelectedIndex = 50; }
                    else if (careerPick >= 95 && careerPick <= 96)
                    { cbCareer.SelectedIndex = 51; }
                    else if (careerPick >= 97 && careerPick <= 98)
                    { cbCareer.SelectedIndex = 52; }
                    else if (careerPick >= 99 && careerPick <= 100)
                    { cbCareer.SelectedIndex = 53; }                   
                    break;
            }
        }

        public void weightRoll()
        {
            var r = new Random();
            int weightRoll = r.Next(1, 100);

            if (weightRoll == 1)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "90"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "80"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "75"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "105"; }
            }
            else if (weightRoll >= 2 && weightRoll <= 3)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "95"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "85"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "75"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "110"; }
            }
            else if (weightRoll >= 4 && weightRoll <= 5)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "100"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "90"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "80"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "115"; }
            }
            else if (weightRoll >= 6 && weightRoll <= 8)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "105"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "95"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "80"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "120"; }
            }
            else if (weightRoll >= 9 && weightRoll <= 12)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "110"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "100"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "85"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "125"; }
            }
            else if (weightRoll >= 13 && weightRoll <= 17)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "115"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "105"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "85"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "130"; }
            }
            else if (weightRoll >= 18 && weightRoll <= 22)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "120"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "110"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "90"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "135"; }
            }
            else if (weightRoll >= 23 && weightRoll <= 29)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "125"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "115"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "90"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "140"; }
            }
            else if (weightRoll >= 30 && weightRoll <= 37)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "130"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "120"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "95"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "145"; }
            }
            else if (weightRoll >= 38 && weightRoll <= 49)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "135"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "125"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "100"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "150"; }
            }
            else if (weightRoll >= 50 && weightRoll <= 64)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "140"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "130"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "100"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "155"; }
            }
            else if (weightRoll >= 65 && weightRoll <= 71)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "145"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "135"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "105"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "160"; }
            }
            else if (weightRoll >= 72 && weightRoll <= 78)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "150"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "140"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "110"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "165"; }
            }
            else if (weightRoll >= 79 && weightRoll <= 83)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "155"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "145"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "115"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "170"; }
            }
            else if (weightRoll >= 84 && weightRoll <= 88)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "160"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "150"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "120"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "175"; }
            }
            else if (weightRoll >= 89 && weightRoll <= 92)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "165"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "155"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "125"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "180"; }
            }
            else if (weightRoll >= 93 && weightRoll <= 95)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "170"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "160"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "130"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "190"; }
            }
            else if (weightRoll >= 96 && weightRoll <= 97)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "175"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "165"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "135"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "200"; }
            }
            else if (weightRoll >= 98 && weightRoll <= 99)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "180"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "170"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "140"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "210"; }
            }
            else if (weightRoll == 100)
            {
                if (cbRace.SelectedIndex == 0)
                { txWeight.Text = "185"; }
                else if (cbRace.SelectedIndex == 1)
                { txWeight.Text = "175"; }
                else if (cbRace.SelectedIndex == 2)
                { txWeight.Text = "145"; }
                else if (cbRace.SelectedIndex == 3)
                { txWeight.Text = "220"; }
            }
        }

        public void eyeColorRoll()
        {
            var r = new Random();
            int eyePick = r.Next(1, 10);

            if (eyePick == 1)
            { cbEyeColor.SelectedIndex = 0; }
            else if (eyePick == 2)
            { cbEyeColor.SelectedIndex = 1; }
            else if (eyePick == 3)
            {
                if (cbRace.SelectedIndex == 2)
                { cbEyeColor.SelectedIndex = 1; }
                else
                { cbEyeColor.SelectedIndex = 2; }
            }
            else if (eyePick == 4)
            {
                if (cbRace.SelectedIndex == 2)
                { cbEyeColor.SelectedIndex = 2; }
                else
                { cbEyeColor.SelectedIndex = 3; }
            }
            else if (eyePick == 5)
            {
                if(cbRace.SelectedIndex ==0)
                { cbEyeColor.SelectedIndex = 3; }
                else if (cbRace.SelectedIndex == 2)
                { cbEyeColor.SelectedIndex = 2; }
                else
                { cbEyeColor.SelectedIndex = 4; }
            }
            else if (eyePick >= 6)
            {
                if (cbRace.SelectedIndex == 0)
                { cbEyeColor.SelectedIndex = 4; }
                else if (cbRace.SelectedIndex == 2)
                { cbEyeColor.SelectedIndex = 3; }
                else
                { cbEyeColor.SelectedIndex = 5; }
            }
            else if (eyePick <= 7)
            {
                if (cbRace.SelectedIndex == 0)
                { cbEyeColor.SelectedIndex = 4; }
                else if (cbRace.SelectedIndex == 2)
                { cbEyeColor.SelectedIndex = 3; }
                else
                { cbEyeColor.SelectedIndex = 6; }
            }
            else if (eyePick >= 8)
            {
                if (cbRace.SelectedIndex == 0)
                { cbEyeColor.SelectedIndex = 5; }
                else if (cbRace.SelectedIndex == 2)
                { cbEyeColor.SelectedIndex = 4; }
                else
                { cbEyeColor.SelectedIndex = 7; }
            }
            else if (eyePick <= 9)
            {
                if (cbRace.SelectedIndex == 0)
                { cbEyeColor.SelectedIndex = 5; }
                else if (cbRace.SelectedIndex == 2)
                { cbEyeColor.SelectedIndex = 4; }
                else
                { cbEyeColor.SelectedIndex = 8; }
            }
            else if (eyePick == 10)
            {
                if (cbRace.SelectedIndex == 0)
                { cbEyeColor.SelectedIndex = 6; }
                else if (cbRace.SelectedIndex == 2)
                { cbEyeColor.SelectedIndex = 4; }
                else
                { cbEyeColor.SelectedIndex = 9; }
            }
        }

        public void hairColorRoll()
        {
            var r = new Random(); 
            int hairPick = r.Next(1, 10);

            if (hairPick == 1)
            { cbHairColor.SelectedIndex = 0; }
            else if (hairPick == 2)
            { cbHairColor.SelectedIndex = 1; }
            else if (hairPick == 3)
            { cbHairColor.SelectedIndex = 2; }
            else if (hairPick == 4)
            {
                if (cbRace.SelectedIndex == 2)
                { cbHairColor.SelectedIndex = 2; }
                else
                { cbHairColor.SelectedIndex = 3; }
            }
            else if (hairPick == 5)
            {
                if (cbRace.SelectedIndex == 2)
                { cbHairColor.SelectedIndex = 3; }
                else
                { cbHairColor.SelectedIndex = 4; }
            }
            else if (hairPick >= 6)
            {
                if (cbRace.SelectedIndex == 2)
                { cbHairColor.SelectedIndex = 4; }
                else
                { cbHairColor.SelectedIndex = 5; }
            }
            else if (hairPick <= 7)
            {
                if (cbRace.SelectedIndex == 3)
                { cbHairColor.SelectedIndex = 6; }
                else
                { cbHairColor.SelectedIndex = 5; }
            }
            else if (hairPick >= 8)
            { cbHairColor.SelectedIndex = 6; }
            else if (hairPick <= 9)
            { cbHairColor.SelectedIndex = 7; }
            else if (hairPick == 10)
            { cbHairColor.SelectedIndex = 8; }
        }

        public void heightRoll()
        {
            var r = new Random();
            int heightRoll = r.Next(1, 10);
            int heightBase = 52;

            switch (cbGender.SelectedIndex)
            {
                case 0:
                    switch (cbRace.SelectedIndex)
                    {
                        case 0:
                            heightBase = 50;
                            break;
                        case 1:
                            heightBase = 64;
                            break;
                        case 2:
                            heightBase = 38;
                            break;
                        case 3:
                            heightBase = 61;
                            break;
                    }
                    break;
                case 1:
                    switch (cbRace.SelectedIndex)
                    {
                        case 0:
                            heightBase = 52;
                            break;
                        case 1:
                            heightBase = 66;
                            break;
                        case 2:
                            heightBase = 40;
                            break;
                        case 3:
                            heightBase = 64;
                            break;
                    }
                    break;
            }

            int heightFeet = (heightBase + heightRoll) / 12;
            txHeight.Text = Convert.ToString(heightFeet) + "\'" + Convert.ToString((heightBase + heightRoll) - (heightFeet * 12)) + "\"";

        }

        public void markRoll(int elf)
        {
            var r = new Random();
            int markRoll = r.Next(1, 100);
            string markText = "";

            if (elf != 1)
            {
                if (markRoll >= 1 && markRoll <= 5)
                {
                    markText = "Pox Marks";
                }
                else if (markRoll >= 6 && markRoll <= 10)
                {
                    markText = "Ruddy Faced";
                }
                else if (markRoll >= 11 && markRoll <= 15)
                {
                    markText = "Scar";
                }
                else if (markRoll >= 16 && markRoll <= 20)
                {
                    markText = "Tattoo";
                }
                else if (markRoll >= 21 && markRoll <= 25)
                {
                    markText = "Earring";
                }
                else if (markRoll >= 26 && markRoll <= 29)
                {
                    markText = "Ragged Ear";
                }
                else if (markRoll >= 30 && markRoll <= 35)
                {
                    markText = "Nose Ring";
                }
                else if (markRoll >= 36 && markRoll <= 39)
                {
                    markText = "Wart";
                }
                else if (markRoll >= 40 && markRoll <= 45)
                {
                    markText = "Broken Nose";
                }
                else if (markRoll >= 46 && markRoll <= 50)
                {
                    markText = "Missing Tooth";
                }
                else if (markRoll >= 51 && markRoll <= 55)
                {
                    markText = "Snaggle Teeth";
                }
                else if (markRoll >= 56 && markRoll <= 60)
                {
                    markText = "Lazy Eye";
                }
                else if (markRoll >= 61 && markRoll <= 65)
                {
                    markText = "Missing Eyebrow(s)";
                }
                else if (markRoll >= 66 && markRoll <= 70)
                {
                    markText = "Missing Digit";
                }
                else if (markRoll >= 71 && markRoll <= 75)
                {
                    markText = "Missing Nail";
                }
                else if (markRoll >= 76 && markRoll <= 80)
                {
                    markText = "Distinctive Gait";
                }
                else if (markRoll >= 81 && markRoll <= 84)
                {
                    markText = "Curious Smell";
                }
                else if (markRoll >= 85 && markRoll <= 89)
                {
                    markText = "Huge Nose";
                }
                else if (markRoll >= 90 && markRoll <= 94)
                {
                    markText = "Large Mole";
                }
                else if (markRoll >= 95 && markRoll <= 98)
                {
                    markText = "Small Bald Patch";
                }
                else if (markRoll >= 99 && markRoll <= 100)
                {
                    markText = "Strange Coloured Eye(s)";
                }
            }

            if (marked == 1)
            { txMarks.Text += ", " + markText; }
            else
            { txMarks.Text += markText; }
            marked = 1;
        }

        public void siblingsRoll()
        {
            var r = new Random();
            int siblingRoll = r.Next(1,10);
            int siblingsnumber = 0;

            switch (siblingRoll)
            {
                case 1:
                    if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 1; }
                    break;
                case 2:
                case 3:
                    if(cbRace.SelectedIndex == 1 || cbRace.SelectedIndex == 3)
                    {siblingsnumber = 1;}
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 2; }
                    break;
                case 4:
                case 5:
                    if (cbRace.SelectedIndex == 0 || cbRace.SelectedIndex == 1)
                    { siblingsnumber = 1; }
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 3; }
                    else if (cbRace.SelectedIndex == 3)
                    { siblingsnumber = 2; }
                    break;
                case 6:
                case 7:
                    if (cbRace.SelectedIndex == 0)
                    { siblingsnumber = 1; }
                    else if (cbRace.SelectedIndex == 1)
                    { siblingsnumber = 2; }
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 4; }
                    else if (cbRace.SelectedIndex == 3)
                    { siblingsnumber = 3; }
                    break;
                case 8:
                case 9:
                    if (cbRace.SelectedIndex == 0 || cbRace.SelectedIndex == 1)
                    { siblingsnumber = 2; }
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 5; }
                    else if (cbRace.SelectedIndex == 3)
                    { siblingsnumber = 4; }
                    break;
                case 10:
                    if (cbRace.SelectedIndex == 0||cbRace.SelectedIndex==1)
                    { siblingsnumber = 3; }
                    else if (cbRace.SelectedIndex == 2)
                    { siblingsnumber = 6; }
                    if (cbRace.SelectedIndex == 3)
                    { siblingsnumber = 5; }
                    break;
            }
            txSiblings.Text = siblingsnumber.ToString();
        }

        public void ageRoll()
        {
            var r = new Random();
            int agePicker = r.Next(1, 100);

            if (agePicker>=1&&agePicker<=5)
            {
                if (cbRace.SelectedIndex == 0 || cbRace.SelectedIndex == 2)
                { txAge.Text = "20"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "30"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "16"; }
            }
            else if (agePicker >= 6 && agePicker <= 10)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "25"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "35"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "22"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "17"; }
            }
            else if (agePicker >= 11 && agePicker <= 15)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "30"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "40"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "24"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "18"; }
            }
            else if (agePicker >= 16 && agePicker <= 20)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "35"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "45"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "26"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "19"; }
            }
            else if (agePicker >= 21 && agePicker <= 25)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "40"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "50"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "28"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "20"; }
            }
            else if (agePicker >= 26 && agePicker <= 30)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "45"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "55"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "30"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "21"; }
            }
            else if (agePicker >= 31 && agePicker <= 35)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "50"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "60"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "32"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "22"; }
            }
            else if (agePicker >= 36 && agePicker <= 40)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "55"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "65"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "34"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "23"; }
            }
            else if (agePicker >= 41 && agePicker <= 45)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "60"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "70"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "36"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "24"; }
            }
            else if (agePicker >= 46 && agePicker <= 50)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "65"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "75"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "38"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "25"; }
            }
            else if (agePicker >= 51 && agePicker <= 55)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "70"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "80"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "40"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "26"; }
            }
            else if (agePicker >= 56 && agePicker <= 60)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "75"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "85"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "42"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "27"; }
            }
            else if (agePicker >= 61 && agePicker <=65)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "80"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "90"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "44"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "28"; }
            }
            else if (agePicker >= 66 && agePicker <= 70)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "85"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "95"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "46"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "29"; }
            }
            else if (agePicker >= 71 && agePicker <= 75)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "90"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "100"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "50"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "30"; }
            }
            else if (agePicker >= 76 && agePicker <= 80)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "95"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "105"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "52"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "31"; }
            }
            else if (agePicker >= 81 && agePicker <= 85)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "100"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "110"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "54"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "32"; }
            }
            else if (agePicker >= 86 && agePicker <= 90)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "105"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "115"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "56"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "33"; }
            }
            else if (agePicker >= 91 && agePicker <= 95)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "110"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "120"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "58"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "34"; }
            }
            else if (agePicker >= 96 && agePicker <= 100)
            {
                if (cbRace.SelectedIndex == 0)
                { txAge.Text = "115"; }
                else if (cbRace.SelectedIndex == 1)
                { txAge.Text = "125"; }
                else if (cbRace.SelectedIndex == 2)
                { txAge.Text = "60"; }
                else if (cbRace.SelectedIndex == 3)
                { txAge.Text = "35"; }
            }
        }

        public void signRoll()
        {
            var r = new Random();
            int signPicker = r.Next(1,100);

            if (signPicker >= 1 && signPicker <= 5)
            { cbStarSign.SelectedIndex = 0; }
            else if (signPicker >= 6 && signPicker <= 10)
            { cbStarSign.SelectedIndex = 1; }
            else if (signPicker >= 11 && signPicker <= 15)
            { cbStarSign.SelectedIndex = 2; }
            else if (signPicker >= 16 && signPicker <= 25)
            { cbStarSign.SelectedIndex = 3; }
            else if (signPicker >= 26 && signPicker <= 30)
            { cbStarSign.SelectedIndex = 4; }
            else if (signPicker >= 31 && signPicker <= 35)
            { cbStarSign.SelectedIndex = 5; }
            else if (signPicker >= 36 && signPicker <= 40)
            { cbStarSign.SelectedIndex = 6; }
            else if (signPicker >= 41 && signPicker <= 45)
            { cbStarSign.SelectedIndex = 7; }
            else if (signPicker >= 46 && signPicker <= 50)
            { cbStarSign.SelectedIndex = 8; }
            else if (signPicker >= 51 && signPicker <= 55)
            { cbStarSign.SelectedIndex = 9; }
            else if (signPicker >= 56 && signPicker <= 60)
            { cbStarSign.SelectedIndex = 10; }
            else if (signPicker >= 61 && signPicker <= 65)
            { cbStarSign.SelectedIndex = 11; }
            else if (signPicker >= 66 && signPicker <= 70)
            { cbStarSign.SelectedIndex = 12; }
            else if (signPicker >= 71 && signPicker <= 75)
            { cbStarSign.SelectedIndex = 13; }
            else if (signPicker >= 76 && signPicker <= 80)
            { cbStarSign.SelectedIndex = 14; }
            else if (signPicker >= 81 && signPicker <= 85)
            { cbStarSign.SelectedIndex = 15; }
            else if (signPicker >= 86 && signPicker <= 90)
            { cbStarSign.SelectedIndex = 16; }
            else if (signPicker >= 91 && signPicker <= 95)
            { cbStarSign.SelectedIndex = 17; }
            else if (signPicker >= 96 && signPicker <= 98)
            { cbStarSign.SelectedIndex = 18; }
            else if (signPicker >= 99 && signPicker <= 100)
            { cbStarSign.SelectedIndex = 19; }
        }

        public void birthRoll()
        {
            var r = new Random();
            int birthPick = r.Next(1, 100);

            switch (cbRace.SelectedIndex)
            {
                case 0:
                    if (birthPick >= 1 && birthPick <= 30)
                    { humBirthplace(); }
                    else if (birthPick >= 31 && birthPick <= 40)
                    { txBirthplace.Text = "Karak Norn (Grey Mountains)"; }
                    else if (birthPick >= 41 && birthPick <= 50)
                    { txBirthplace.Text = "Karak Izor (the Vaults)"; }
                    else if (birthPick >= 51 && birthPick <= 60)
                    { txBirthplace.Text = "Karak Hirn (Black Mountains)"; }
                    else if (birthPick >= 61 && birthPick <= 70)
                    { txBirthplace.Text = "Karak Kadrin (World's Edge Mountains)"; }
                    else if (birthPick >= 71 && birthPick <= 80)
                    { txBirthplace.Text = "Karaz-A-Karak (World's Edge Mountains)"; }
                    else if (birthPick >= 81 && birthPick <= 90)
                    { txBirthplace.Text = "Zhufbar (World's Edge Mountains)"; }
                    else if (birthPick >= 91 && birthPick <= 100)
                    { txBirthplace.Text = "Barak Varr (the Black Gulf)"; }
                    break;
                case 1:
                    if (birthPick >= 1 && birthPick <= 20)
                    { txBirthplace.Text = "City of Altdorf"; }
                    else if (birthPick >= 21 && birthPick <= 40)
                    { txBirthplace.Text = "City of Marienburg"; }
                    else if (birthPick >= 41 && birthPick <= 70)
                    { txBirthplace.Text = "Laurelorn Forest"; }
                    else if (birthPick >= 71 && birthPick <= 85)
                    { txBirthplace.Text = "The Great Forest"; }
                    else if (birthPick >= 86 && birthPick <= 100)
                    { txBirthplace.Text = "Reikwald Forest"; }
                    break;
                case 2:
                    if (birthPick <= 50)
                    { txBirthplace.Text = "The Moot"; }
                    else { humBirthplace(); }
                    break;
                case 3:
                    humBirthplace();
                    break;
            }
        }

        public void humBirthplace()
        {
            var r = new Random();
            int roll1 = r.Next(1, 10);
            int roll2 = r.Next(1, 10);
            string part1 = "";
            string part2 = "";

            if (cbCareer.Text == "Noble")
            { roll2 = r.Next(1, 4); }

            if (cbCareer.Text == "Norse Berserker")
            { roll1 = 4; }

            switch (roll1)
            {
                case 1:
                    part1 = "Averland";
                    break;
                case 2:
                    part1 = "Hochland";
                    break;
                case 3:
                    part1 = "Middenland";
                    break;
                case 4:
                    part1 = "Nordland";
                    break;
                case 5:
                    part1 = "Ostermark";
                    break;
                case 6:
                    part1 = "Ostland";
                    break;
                case 7:
                    part1 = "Reikland";
                    break;
                case 8:
                    part1 = "Stirland";
                    break;
                case 9:
                    part1 = "Talabecland";
                    break;
                case 10:
                    part1 = "Wissenland";
                    break;
            }

            switch (roll2)
            {
                case 1:
                    part2 = "City";
                    break;
                case 2:
                    part2 = "Prosperous Town";
                    break;
                case 3:
                    part2 = "Market Town";
                    break;
                case 4:
                    part2 = "Fortified Town";
                    break;
                case 5:
                    part2 = "Farming Village";
                    break;
                case 6:
                    part2 = "Poor Village";
                    break;
                case 7:
                    part2 = "Small Settlement";
                    break;
                case 8:
                    part2 = "Pig/Cattle Farm";
                    break;
                case 9:
                    part2 = "Arable Farm";
                    break;
                case 10:
                    part2 = "Hovel";
                    break;
            }

            txBirthplace.Text = part1 + ", " + part2;
        }

        public void careerChanged()
        {
            libEquipment.Items.Clear();
            libEquipment.Items.AddRange(new object[] {
            "common clothes (shirt, breeches/skirt, worn boots)",
            "tattered cloak",
            "dagger",
            "backpack or slingbag",
            "blanket",
            "wooden tankard",
            "wooden cutlery",
            "hand weapon(sword, axe, club, etc.)"});

            libSkills.Items.Clear();
            libSkills.Items.AddRange(new object[] {
                rSkill1,
                rSkill2,
                rSkill3});

            if (rSkill4 != "")
            { libSkills.Items.Add(rSkill4); }
            if (rSkill5 != "")
            { libSkills.Items.Add(rSkill5); }
            if (rSkill6 != "")
            { libSkills.Items.Add(rSkill6); }

            libTalents.Items.Clear();
            libTalents.Items.AddRange(new object[] {
                rTallent1,
                rTallent2});

            if (rTallent3 != "")
            { libTalents.Items.Add(rTallent3); }
            if (rTallent4 != "")
            { libTalents.Items.Add(rTallent4); }
            if (rTallent5 != "")
            { libTalents.Items.Add(rTallent5); }
            if (rTallent6 != "")
            { libTalents.Items.Add(rTallent6); }

            switch(cbCareer.Text)
            {
                case "Agitator":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text="";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (History) or Gossip",
                        "Academic Knowledge (Law) or Common Knowledge (the Empire)",
                        "Concealment",
                        "Charm",
                        "Perception",
                        "Read/Write",
                        "Speak Language (Breaton or Tilean)"});
                    libTalents.Items.AddRange(new object[] {
                        "Coolheaded or Street Fighting",
                        "Flee!",
                        "Public Speaking"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jack",
                        "One set Good Craftsmanship Clothes",
                        "leaflets for various causes"});
                    break;
                case "Apprentice Wizard":
                    txWeaponSkilAdvance.Text = "";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "15";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text="";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "1";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (Magic)",
                        "Channelling",
                        "Magical Sense",
                        "Perception",
                        "Read/Write",
                        "Search",
                        "Speak Arcane Language (Magick)",
                        "Speak Language (Clasical)"});
                    libTalents.Items.AddRange(new object[] {
                        "Aethyric Attunement or Fast Hands",
                        "Petty Magic (Arcane)",
                        "Savvy or Very Resilient"});
                    libEquipment.Items.AddRange(new object[]{
                        "Quarter Staff",
                        "Printed Book"});
                    break;
            }

            txGold.Text = Convert.ToString(startingGold + careerGold);
        }

        private string randomTalent()
        {
            var r = new Random();
            int roll = r.Next(1, 100);
            string tallent = "";
            string[] randTallents = { "Acute Hearing",
                                      "Ambidextrous",
                                      "Coolheaded",
                                      "Excelent Vision",
                                      "Fleet Footed",
                                      "Hardy",
                                      "Lightning Reflexes",
                                      "Luck",
                                      "Marksman",
                                      "Mimic",
                                      "Night Vision",
                                      "Resistance to Disease",
                                      "Resistance to Magic",
                                      "Resistance to Poison",
                                      "Savvy",
                                      "Sixth Sense",
                                      "Strong-minded",
                                      "Sturdy",
                                      "Suave",
                                      "Super Numerate",
                                      "Very Resilient",
                                      "Very Strong",
                                      "Warrior Born"};

            switch (cbRace.SelectedIndex)
            {
                case 2:
                    if (roll >= 1 && roll <= 5)
                    { tallent = randTallents[1]; }
                    else if (roll >= 6 && roll <= 10)
                    { tallent = randTallents[2]; }
                    else if (roll >= 11 && roll <= 15)
                    { tallent = randTallents[3]; }
                    else if (roll >= 16 && roll <= 20)
                    { tallent = randTallents[4]; }
                    else if (roll >= 21 && roll <= 25)
                    { tallent = randTallents[5]; }
                    else if (roll >= 26 && roll <= 29)
                    { tallent = randTallents[6]; }
                    else if (roll >= 30 && roll <= 33)
                    { tallent = randTallents[7]; }
                    else if (roll >= 34 && roll <= 38)
                    { tallent = randTallents[8]; }
                    else if (roll >= 39 && roll <= 42)
                    { tallent = randTallents[9]; }
                    else if (roll >= 43 && roll <= 47)
                    { tallent = randTallents[10]; }
                    else if (roll >= 48 && roll <= 51)
                    { tallent = randTallents[12]; }
                    else if (roll >= 52 && roll <= 53)
                    { tallent = randTallents[13]; }
                    else if (roll >= 54 && roll <= 57)
                    { tallent = randTallents[14]; }
                    else if (roll >= 58 && roll <= 62)
                    { tallent = randTallents[15]; }
                    else if (roll >= 63 && roll <= 67)
                    { tallent = randTallents[16]; }
                    else if (roll >= 68 && roll <= 72)
                    { tallent = randTallents[17]; }
                    else if (roll >= 73 && roll <= 77)
                    { tallent = randTallents[18]; }
                    else if (roll >= 78 && roll <= 82)
                    { tallent = randTallents[19]; }
                    else if (roll >= 83 && roll <= 87)
                    { tallent = randTallents[20]; }
                    else if (roll >= 88 && roll <= 91)
                    { tallent = randTallents[21]; }
                    else if (roll >= 92 && roll <= 95)
                    { tallent = randTallents[22]; }
                    else if (roll >= 96 && roll <= 100)
                    { tallent = randTallents[23]; }
                    break;
                case 3:
                    if (roll >= 1 && roll <= 4)
                    { tallent = randTallents[1]; }
                    else if (roll >= 5 && roll <= 9)
                    { tallent = randTallents[2]; }
                    else if (roll >= 10 && roll <= 13)
                    { tallent = randTallents[3]; }
                    else if (roll >= 14 && roll <= 18)
                    { tallent = randTallents[4]; }
                    else if (roll >= 19 && roll <= 22)
                    { tallent = randTallents[5]; }
                    else if (roll >= 23 && roll <= 27)
                    { tallent = randTallents[6]; }
                    else if (roll >= 28 && roll <= 31)
                    { tallent = randTallents[7]; }
                    else if (roll >= 32 && roll <= 35)
                    { tallent = randTallents[8]; }
                    else if (roll >= 36 && roll <= 40)
                    { tallent = randTallents[9]; }
                    else if (roll >= 41 && roll <= 44)
                    { tallent = randTallents[10]; }
                    else if (roll >= 45 && roll <= 49)
                    { tallent = randTallents[11]; }
                    else if (roll >= 50 && roll <= 53)
                    { tallent = randTallents[12]; }
                    else if (roll >= 54 && roll <= 57)
                    { tallent = randTallents[13]; }
                    else if (roll >= 58 && roll <= 61)
                    { tallent = randTallents[14]; }
                    else if (roll >= 62 && roll <= 66)
                    { tallent = randTallents[15]; }
                    else if (roll >= 67 && roll <= 71)
                    { tallent = randTallents[16]; }
                    else if (roll >= 72 && roll <= 75)
                    { tallent = randTallents[17]; }
                    else if (roll >= 76 && roll <= 79)
                    { tallent = randTallents[18]; }
                    else if (roll >= 80 && roll <= 83)
                    { tallent = randTallents[19]; }
                    else if (roll >= 84 && roll <= 87)
                    { tallent = randTallents[20]; }
                    else if (roll >= 88 && roll <= 91)
                    { tallent = randTallents[21]; }
                    else if (roll >= 92 && roll <= 95)
                    { tallent = randTallents[22]; }
                    else if (roll >= 96 && roll <= 100)
                    { tallent = randTallents[23]; }
                    break;
            }

            return tallent;
        }

        public void raceSkills()
        {
            switch (cbRace.SelectedIndex)
            {
                case 0:
                    rSkill2 = "Common Knowledge (Dwarfs)";
                    rSkill3 = "Speak Language (Khazalid)";
                    rSkill4 = "Trade (Miner, Smith, or Stoneworker)";
                    rSkill5 = "";
                    rSkill6 = "";
                    rTallent1 = "Dwarfcraft";
                    rTallent2 = "Grudge-born Fury";
                    rTallent3 = "Night Vision";
                    rTallent4 = "Resistance to Magic";
                    rTallent5 = "Stout-hearted";
                    rTallent6 = "Sturdy";
                    break;
                case 1:
                    rSkill2 = "Common Knowledge (Elves)";
                    rSkill3 = "Speak Language (Eltharin)";
                    rSkill4 = "";
                    rSkill5 = "";
                    rSkill6 = "";
                    rTallent1 = "Aethyric Attunement or Specialist Weapon Group (Longbow)";
                    rTallent2 = "Coolheaded or Savvy";
                    rTallent3 = "Excellent Vision";
                    rTallent4 = "Night Vision";
                    rTallent5 = "";
                    rTallent6 = "";
                    break;
                case 2:
                    rSkill2 = "Academic Knowledge (Genealogy/Heraldry";
                    rSkill3 = "Common Knowledge (Halflings)";
                    rSkill4 = "Gossip";
                    rSkill5 = "Speak Language (Halfling)";
                    rSkill6 = "Trade (Cook or Farmer)";
                    rTallent1 = "Night Vision";
                    rTallent2 = "Resistance to Chaos";
                    rTallent3 = "Specialist Weapon Group (Sling)";
                    rTallent4 = randomTalent();
                    rTallent5 = "";
                    rTallent6 = "";
                    break;
                case 3:
                    rSkill2 = "Common Knowledge (the Empire)";
                    rSkill3 = "Gossip";
                    rSkill4 = "";
                    rSkill5 = "";
                    rSkill6 = "";
                    rTallent1 = randomTalent();
                    rTallent2 = randomTalent();
                    rTallent3 = "";
                    rTallent4 = "";
                    rTallent5 = "";
                    rTallent6 = "";
                    break;
            }
        }

        private void btRerollChar_Click(object sender, EventArgs e)
        {
            txMarks.Text = "";
            marked = 0;
            characterGen();
        }

        private void btRerollStats_Click(object sender, EventArgs e)
        {
            statsRoll();
        }

        private void btAddMark_Click(object sender, EventArgs e)
        {
            markRoll(0);
        }

        private void btRerollMark_Click(object sender, EventArgs e)
        {
            int elf = 0;

            if (cbRace.SelectedIndex == 1)
            { elf = 1; }
            else { elf = 0; }

            txMarks.Text = "";
            marked = 0;
            markRoll(elf);
        }

        private void cbRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            txMarks.Text = "";
            marked = 0;

            characterGen();
        }

        private void cbCareer_SelectedIndexChanged(object sender, EventArgs e)
        {
            careerChanged();
        }

        private void btCareerRoll_Click(object sender, EventArgs e)
        {
            careerRoll();
        }
    }
}
