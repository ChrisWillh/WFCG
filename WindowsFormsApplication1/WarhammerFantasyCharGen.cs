﻿using System;
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

            if (cbCareer.Text == "Kithband Warrior")
            { birthPick = r.Next(41, 100); }

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

            if (cbCareer.Text == "Estalian Diestro")
            { part1 = "Estalia"; }
            if (cbCareer.Text == "KisleVite Kossar")
            { part1 = "Kislev"; }
            if (cbCareer.Text == "Norse Berserker")
            { part1 = "Norsca"; }

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
            var r = new Random();

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
                        "Academic Knowledge (Law)",
                        "or Common Knowledge (the Empire)",
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
                case "Bailiff":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (Law)",
                        "Animal Care or Gossip",
                        "Charm",
                        "Command or Navigation",
                        "Intimidate",
                        "or Common Knowledge (the Empire)",
                        "Perception",
                        "Read/Write",
                        "Ride"});
                    libTalents.Items.AddRange(new object[] {
                        "Etiquette or Super Numerate",
                        "Public Speaking"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jack",
                        "Leather Skullcap",
                        "Riding Horse w/ Saddle & Harness",
                        "One set Good Craftsmanship Clothing"});
                    break;
                case "Barber-Surgeon":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Charm",
                        "Drive or Swim",
                        "Haggle",
                        "Heal",
                        "Perception",
                        "Read/Write",
                        "Speak Arcane Language (Breaton or Tilean)",
                        "Trade (Apothecary)"});
                    libTalents.Items.AddRange(new object[] {
                        "Resistance to Disease or Savvy",
                        "Suave or Very Resilient",
                        "Surgery"});
                    libEquipment.Items.AddRange(new object[]{
                        "Trade Tools (Barber-Surgeon)"});
                    break;
                case "Boatman":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (the Empire ot Kislev)",
                        "Consume Alcohol or Gossip",
                        "Navigation",
                        "Outdoor Survival",
                        "Perception",
                        "Row",
                        "Sail",
                        "Secret Language (Ranger)",
                        "or Speak Language (Kislevian)",
                        "Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Orientation",
                        "Seasoned Traveller"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jack",
                        "Row Boat"});
                    break;
                case "Bodyguard":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "3";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Dodge Blow",
                        "Heal",
                        "Intimidate",
                        "Perception"});
                    libTalents.Items.AddRange(new object[] {
                        "Disarm or Quick Draw",
                        "Specialist Weapon Group (Parrying)",
                        "Specialist Weapong Group (Throwing)",
                        "Street Fighting",
                        "Strike to Stun",
                        "Very Strong or Very Resilient"});
                    libEquipment.Items.AddRange(new object[]{
                        "Buckler",
                        "Knuckle-dusters",
                        "2 Throwing Axes or Throwing Knives",
                        "Leather Jack"});
                    break;
                case "Bone Picker":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "10";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care",
                        "Charm or Gossip",
                        "Drive",
                        "Common Knowledge (the Empire)",
                        "Evaluate",
                        "Haggle",
                        "Perception",
                        "Search"});
                    libTalents.Items.AddRange(new object[] {
                        "Coolheaded or Streetwise",
                        "Hardy or Resistance to Disease"});
                    libEquipment.Items.AddRange(new object[]{
                        "Cart",
                        "3 Sacks"});
                    break;
                case "Bounty Hunter":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Follow Trail",
                        "Intimidate",
                        "Outdoor Survival",
                        "Perception",
                        "Search",
                        "Shadowing",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Marksman or Strike to Stun",
                        "Specialist Weapon Group (Entangling)",
                        "Sharpshooter or Strike Mighty Blow"});
                    libEquipment.Items.AddRange(new object[]{
                        "Crossbow w/ 10 bolts",
                        "Net",
                        "Leather Jerkin",
                        "Leather Skullcap",
                        "Manacles",
                        "10 Yards of Rope"});
                    break;
                case "Burgher":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (the Empire)",
                        "or Consume Alcohol",
                        "Drive",
                        "Evaluate",
                        "Gossip or Read/Write",
                        "Haggle",
                        "Perception",
                        "Search",
                        "Speak Language (Breaton, Kislevian,",
                        "or Tilean)"});
                    libTalents.Items.AddRange(new object[] {
                        "Dealmaker",
                        "Savvy or Suave"});
                    libEquipment.Items.AddRange(new object[]{
                        "Abacus",
                        "Lantern",
                        "One set of Good Clothing"});
                    break;
                case "Camp Follower":
                    txWeaponSkilAdvance.Text = "";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care or Drive",
                        "Charm or Evaluate",
                        "Gossip",
                        "Haggle",
                        "Perception",
                        "Search",
                        "Any one of:",
                        "Trade (Armourer, Bowyer, Cartographer,",
                        "Cook, Gunsmith, Herbalist, Merchant, Smith,",
                        "Tailor, or Weaponsmith)",
                        "Speak Language (Breaton, Kislevian,",
                        "or Tilean)",
                        "Slight of Hand"});
                    libTalents.Items.AddRange(new object[] {
                        "Dealmaker or Street Figher",
                        "Flee!",
                        "Hardy or Suave",
                        "Resistance to Disease or Seasoned Traveller"});
                    libEquipment.Items.AddRange(new object[]{
                        "Lucky Charm or Trade Tools",
                        "Pouch",
                        "Tent"});
                    break;
                case "Charcoal-Burner":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (the Empire) or Concealment",
                        "Drive or Gossip",
                        "Haggle",
                        "Outdoor Survival",
                        "Perception",
                        "Scale Sheer Surface",
                        "Search",
                        "Secret Signs (Ranger)"});
                    libTalents.Items.AddRange(new object[] {
                        "Flee!",
                        "Savvy or Very Strong"});
                    libEquipment.Items.AddRange(new object[]{
                        "3 Torches",
                        "Tinderbox",
                        "Hand Weapon (Hatchet)"});
                    break;
                case "Coachman":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care",
                        "Drive",
                        "Gossip or Haggle",
                        "Heal or Ride",
                        "Navigation",
                        "Perception",
                        "Secret Signs (Ranger)",
                        "Speak Language (Breaton, Kislevian, or Tilean"});
                    libTalents.Items.AddRange(new object[] {
                        "Quick Draw or Seasoned Traveller",
                        "Specialist Weapon Group (Gunpowder)"});
                    libEquipment.Items.AddRange(new object[]{
                        "Blunderbuss w/ 10 shots",
                        "Mail Shirt and Leather Jack",
                        "Instrument (Coach Horn)"});
                    break;
                case "Entertainer":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care or Swim",
                        "Common Knowledge (the Empire)",
                        "Evaluate or Gossip",
                        "Perception",
                        "Performer (any two)",
                        "Any one of:",
                        "Animal Training",
                        "Blather",
                        "Charm Animal",
                        "Hypnotism",
                        "Ride",
                        "Scale Sheer Surface",
                        "Sleight of Hand",
                        "Ventriloquism"});
                    libTalents.Items.AddRange(new object[] {
                        "Any two of:",
                        "Lightning Reflexes",
                        "Mimic",
                        "Public Speaking",
                        "Quick Draw",
                        "Sharpshooter",
                        "Specialist Weapon Group (Throwing)",
                        "Trick Riding",
                        "Very Strong",
                        "Wrestling"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jerkin",
                        "Any one of:",
                        "Instrument (any one)",
                        "Trade Tools (Performer)",
                        "3 Throwing Knives",
                        "2 Throwing Axes",
                        "Any one of:",
                        "Costume",
                        "One set of Good Crafstmanship Clothes"});
                    break;
                case "Envoy":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Charm",
                        "Common Knowledge (the Empire or the Wasteland)",
                        "Evaluate",
                        "Gossip",
                        "Haggle",
                        "Perception",
                        "Read/Write",
                        "Secret Language (Guild Tounge)",
                        "Swim",
                        "Trade (Merchant)"});
                    libTalents.Items.AddRange(new object[] {
                        "Deal Maker or Seasoned Traveller"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jack",
                        "2 sets of Good Craftsmanship Clothes",
                        "Writing Kit"});
                    break;
                case "Estalian Diestro":
                    txWeaponSkilAdvance.Text = "15";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (Science)",
                        "Common Knowledge (Estalia)",
                        "Dodge Blow",
                        "Read/Write",
                        "Speak Language (Estalain)"});
                    libTalents.Items.AddRange(new object[] {
                        "Lightning Reflexes or Swashbuckler",
                        "Quick Draw or Strick to Injure",
                        "Specialist Weapon Group (Fencing)",
                        "Strick Mighty Blow"});
                    libEquipment.Items.AddRange(new object[]{
                        "Foil or Rapier",
                        "One set of Best Craftsmanship Clothes",
                        "Perfume or Cologne",
                        "Healing Draught"});
                    break;
                case "Ferryman":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "10";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Charm",
                        "Common Knowlede (the Empire)",
                        "Evaluate or Secret Language (Ranger)",
                        "Gossip or Intimidate",
                        "Haggle",
                        "Perception",
                        "Row",
                        "Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Marksman or Suave",
                        "Specialist Weapon Group (Gunpowder) or Street Fighting"});
                    libEquipment.Items.AddRange(new object[]{
                        "Crossbow w/ 10 bolts or Blunderbuss w/ 10 shot",
                        "Leather Jack"});
                    break;
                case "Fieldwarden":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (Necromancy)",
                        "or Common Knowledge (the Empire",
                        "Concealment",
                        "Follow Trail",
                        "Outdoor Survival",
                        "Perception",
                        "Search",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Fleet Footed or Savvy",
                        "Mighty Shot or Rapid Reload",
                        "Rover or Quick Draw"});
                    libEquipment.Items.AddRange(new object[]{
                        "Sling w/ Ammo",
                        "Lantern",
                        "Lamp Oil",
                        "Spade",
                        "Pony w/ Saddle & Harness"});
                    break;
                case "Fisherman":
                    txWeaponSkilAdvance.Text = "";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "10";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (the Empire or the Wasteland",
                        "Consume Alcohol or Haggle",
                        "Navigation or Trade (Merchant)",
                        "Outdoor Survival",
                        "Perception",
                        "Row",
                        "Sail",
                        "Speak Language (Norse)",
                        "Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Hardy or Savvy",
                        "Orientation or Street Fighting"});
                    libEquipment.Items.AddRange(new object[]{
                        "Fish Hook and Line",
                        "Spear"});
                    break;
                case "Grave Robber":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Drive",
                        "Gossip or Haggle",
                        "Perception",
                        "Scale Sheer Surface",
                        "Search",
                        "Secret Signs (Thief)",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Flee!",
                        "Resistance to Disease",
                        "Streetwise or Strongminded"});
                    libEquipment.Items.AddRange(new object[]{
                        "Lantern",
                        "Lamp Oil",
                        "Pick",
                        "Sack",
                        "Spade"});
                    break;
                case "Hedge Wizard":
                    txWeaponSkilAdvance.Text = "";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "1";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care or Haggle",
                        "Charm or Intimidate",
                        "Channelling",
                        "Charm Animal or Trade (Apothecary)",
                        "Heal or Hypnotism",
                        "Magic Sense",
                        "Perception",
                        "Search"});
                    libTalents.Items.AddRange(new object[] {
                        "Hedge Magic",
                        "Petty Magic (Hedge)"});
                    libEquipment.Items.AddRange(new object[]{
                        "Healing Draught",
                        "Hood"});
                    break;
                case "Hunter":
                    txWeaponSkilAdvance.Text = "";
                    txBalisticSkilAdvance.Text = "15";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "3";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Concealment",
                        "Follow Trail",
                        "Outdoor Survival",
                        "Perception",
                        "Search or Swim",
                        "Secret Signs (Ranger)",
                        "Silent Mover or Set Trap"});
                    libTalents.Items.AddRange(new object[] {
                        "Hardy or Specialist Weapon Group (Longbow)",
                        "Lightning Reflexes or Very Resilient",
                        "Marksman or Rover",
                        "Rapid Reload"});
                    libEquipment.Items.AddRange(new object[]{
                        "Longbow w/ 10 arrows",
                        "2 Animal Traps",
                        "Antitoxin Kit"});
                    break;
                case "Initiate":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (Astronomy or History)",
                        "Academic Knowledge (Theology)",
                        "Charm",
                        "Heal",
                        "Perception",
                        "Read/Write",
                        "Speak Language (Classical)"});
                    libTalents.Items.AddRange(new object[] {
                        "Lightning Reflexes or Very Strong",
                        "Public Speaking",
                        "Suave or Warrior Born"});
                    libEquipment.Items.AddRange(new object[]{
                        "Religious Symbol",
                        "Robes"});
                    break;
                case "Jailer":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "10";
                    txToughnesAdvance.Text = "10";
                    txAgilityAdvance.Text = "";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "3";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Command",
                        "Consume Alcohol",
                        "Dodge Blow",
                        "Heal or Sleight of Hand",
                        "Intimidate",
                        "Perception",
                        "Search"});
                    libTalents.Items.AddRange(new object[] {
                        "Resistance to Disease",
                        "Resistance to Poison",
                        "Specialist Weapon Group (Entangling)",
                        "Wrestling"});
                    libEquipment.Items.AddRange(new object[]{
                        "Bottle of Common Wine",
                        "Any one of: Bola, Lasso, Net"});
                    break;
                case "KisleVite Kossar":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "10";
                    txAgilityAdvance.Text = "";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (Kislev)",
                        "Consume Alcohol",
                        "Dodge Blow",
                        "Gamble or Gossip",
                        "Outdoor Survival",
                        "Perception",
                        "Search",
                        "Speak Language (Kislevian)"});
                    libTalents.Items.AddRange(new object[] {
                        "Specialist Weapon Group (Two Handed)",
                        "Strike to Injure"});
                    libEquipment.Items.AddRange(new object[]{
                        "Bow w/ 10 Arrows",
                        "Great Weapon (Two-Handed Axe)",
                        "Mail Coat",
                        "Leather Jack",
                        "Leather Leggings"});
                    break;
                case "Kithband Warrior":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Concealment",
                        "Dodge Blow",
                        "Follow Trail",
                        "Heal or Search",
                        "Outdoor Survival",
                        "Perception",
                        "Scale Sheer Surface",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Marksman or Rover",
                        "Rapid Reload or Warrior Born"});
                    libEquipment.Items.AddRange(new object[]{
                        "Elfbow w/ 10 Arrows",
                        "Leather Jack"});
                    break;
                case "Marine":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "10";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "3";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (the Wasteland) or Gamble",
                        "Consume Alcohol",
                        "Dodge Blow",
                        "Gossip or Secret Language (Battle Tongue",
                        "Intimidate",
                        "Row",
                        "Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Disaem or Quick Draw",
                        "Strike Mighty Blow",
                        "Strike to Stun"});
                    libEquipment.Items.AddRange(new object[]{
                        "Bow or Crossbow /w 10 Arrows or Bolts",
                        "Leather Jack",
                        "Shield",
                        "Grappling Hook",
                        "10 Yards of Rope"});
                    break;
                case "Mercenary":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care or Gamble",
                        "Common Knowldge (Bretonnia, Kislev, or Tilea)",
                        "Dodge Blow",
                        "Drive or Ride",
                        "Gossip or Haggle",
                        "Perception or Search",
                        "Secret Language (Battle Tongue)",
                        "Speak Language (Tilean) or Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Disarm or Quick Draw",
                        "Rapid Reload or Strike Mighty Blow",
                        "Sharpshooter or Strike to Stun"});
                    libEquipment.Items.AddRange(new object[]{
                        "Crossbow w/ 10 Bolts",
                        "Shield",
                        "Mail Shirt",
                        "Leather Jack",
                        "Healing Draught"});
                    break;
                case "Messenger":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care",
                        "Common Knowledge (the Empire or the Wasteland)",
                        "or Gossip",
                        "Navigation",
                        "Outdoor Survival",
                        "Secret Signs (Scout)",
                        "Perception",
                        "Ride",
                        "Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Orientation",
                        "Seasoned Traveller"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jack",
                        "Map case",
                        "Riding Horse w/ Saddle & Harness or Pony for Halfling",
                        "Shield"});
                    break;
                case "Militiaman":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care",
                        "Dodge Blow",
                        "Drive or Swim",
                        "Gamble or Gossip",
                        "Outdoor Survival",
                        "Perception",
                        "Search",
                        "Trade (any one"});
                    libTalents.Items.AddRange(new object[] {
                        "Specialist Weapon Group (Two-Handed)",
                        "or Rapid Reload",
                        "Strike Mighty Blow"});
                    libEquipment.Items.AddRange(new object[]{
                        "Halber or Bow w/ 10 Arrows",
                        "Leather Jack",
                        "Leather Skullcap",
                        "Uniform"});
                    break;
                case "Miner":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "10";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care",
                        "Concealment or Drive",
                        "Evaluate or Outdoor Survival",
                        "Navigation",
                        "Perception",
                        "Scale Sheer Surface",
                        "Trade (Miner or Prospector)"});
                    libTalents.Items.AddRange(new object[] {
                        "Orientation",
                        "Specialist Weapon group (Two-handed)",
                        "Very Resilient or Warrior Born"});
                    libEquipment.Items.AddRange(new object[]{
                        "Great Weapon (Two-handed Pick)",
                        "Leather Jack",
                        "Pick",
                        "Spade",
                        "Storm Lantern",
                        "Lamp Oil"});
                    break;
                case "Noble":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Blather or Command",
                        "Common Knowledge (the Empire)",
                        "Consume Alcohol or Performer (Musician)",
                        "Charm",
                        "Gamble or Gossip",
                        "Read/Write",
                        "Ride"});
                    libTalents.Items.AddRange(new object[] {
                        "Etiquette",
                        "Luck or Public Speaking",
                        "Savvy or Specialist Weapon (Fencing)",
                        "Schemer or Specialist Weapon (Parrying)"});
                    libEquipment.Items.AddRange(new object[]{
                        "Foil",
                        "Main Gauche",
                        "Noble's Garb",
                        "Riding Horse w/ Saddle and Harness",
                        "Jewellery worth 6d10 GC"});
                    careerGold = r.Next(1, 10);
                    break;
                case "Norse Berserker":
                    txWeaponSkilAdvance.Text = "15";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "10";
                    txToughnesAdvance.Text = "10";
                    txAgilityAdvance.Text = "";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (Norsca)",
                        "Consume Alcohol",
                        "Intimidate",
                        "Performer (Storyteller)",
                        "Speak Language (Norse)",
                        "Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Frenzy",
                        "Menacing",
                        "Quick Draw",
                        "Specialist Weapon Group (Two-Handed)"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jerkin",
                        "Bottle of Spirits",
                        "Great Weapon or Shield"});
                    break;
                case "Outaw":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care or Common Knowledge (the Empire)",
                        "Concealment",
                        "Dodge Blow",
                        "Drive or Ride",
                        "Gossip or Secret Signs (Thief)",
                        "Perception",
                        "Scalre Sheer Surface",
                        "Set Trap or Swim",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Rover or Streetwise",
                        "Sharpshooter or Strike to Stun"});
                    libEquipment.Items.AddRange(new object[]{
                        "Bow w/ 10 Arrows",
                        "Leather Jerkin",
                        "Shield"});
                    break;
                case "Outrider":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care",
                        "Follow Trail",
                        "Navigation",
                        "Outdoor Survival",
                        "Perception",
                        "Ride",
                        "Search",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Coolheaded or Very Strong",
                        "Orientation",
                        "Specialist Weapon Group (Entangling)"});
                    libEquipment.Items.AddRange(new object[]{
                        "Bow or Crossbow w/ 10 Arrows or Bolts",
                        "Net",
                        "Whip or Laso",
                        "Lether Jack",
                        "Shield",
                        "10 Yards of Rope",
                        "Riding Horse 1/ Saddle & Harness"});
                    break;
                case "Peasant":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "10";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care or Charm",
                        "Animal Training or Swim",
                        "Charm Animal or Trade (Cook)",
                        "Concealment",
                        "Drive or Trade (Bowyer)",
                        "Gamble or Performer (Dancer or Singer)",
                        "Outdoor Survival or Trade (Farmer)",
                        "Row or Set Trap",
                        "Scale Sheer Surface or Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Hardy or Rover",
                        "Flee or Specialist Weapon Group (Sling)"});
                    libEquipment.Items.AddRange(new object[]{
                        "Sling or Quarter Staff",
                        "Leather Flask"});
                    break;
                case "Pit Figher":
                    txWeaponSkilAdvance.Text = "15";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "10";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Dodge Blow",
                        "Intimidate"});
                    libTalents.Items.AddRange(new object[] {
                        "Disarm or Wrestling",
                        "Quick Draw or Strike to Injure",
                        "Specialist Weapon Group (Flail)",
                        "Specialist Weapon Group (Parrying)",
                        "Specialist Weapon Group (Two-Handed)",
                        "Strike Mighty Blow",
                        "Very Strong or Strong-minded"});
                    libEquipment.Items.AddRange(new object[]{
                        "Flail or Great Weapon",
                        "Knuckle-duster",
                        "Shield or Buckler",
                        "Mail Shirt and Leather Jack"});
                    break;
                case "Protagonist":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "10";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Dodge Blow",
                        "Gossip or Haggle",
                        "Intimidate",
                        "Ride"});
                    libTalents.Items.AddRange(new object[] {
                        "Disarm or Quick Draw",
                        "Menacing or Suave",
                        "Street Fighting",
                        "Strike Mighty Blow",
                        "Strike to Injure",
                        "Strike to Stun"});
                    libEquipment.Items.AddRange(new object[]{
                        "Mail Shirt",
                        "Leather Jack",
                        "Shield",
                        "Riding Hores w/ Saddle and Harness"});
                    break;
                case "Rat Catcher":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care",
                        "Animal Trainer",
                        "Concealment",
                        "Perception",
                        "Search",
                        "Set Trap",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Resistance to Disease",
                        "Resistance to Poison",
                        "Specialist Weapon Group (Sling)",
                        "Tunnel Rat"});
                    libEquipment.Items.AddRange(new object[]{
                        "Sling w/ Ammo",
                        "4 Animal Traps",
                        "Pole with 1d10 dead rats",
                        "Small but Vicious Dog"});
                    break;
                case "Roadwarden":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care",
                        "Common Knowledge (the Empire) or Gossip",
                        "Drive",
                        "Follow Trail or Secret Signs (Scout)",
                        "Navigation",
                        "Outdoor Survival",
                        "Perception",
                        "Ride",
                        "Search"});
                    libTalents.Items.AddRange(new object[] {
                        "Quick Draw or Rapid Reload",
                        "Specialist Weapons Group (Gunpowder)"});
                    libEquipment.Items.AddRange(new object[]{
                        "Pistol w/ 10 Shot",
                        "Mail Shirt",
                        "Leather Jack",
                        "Shield",
                        "10 Yards of Rope",
                        "Light Warhorse w/ Saddle & Harness (Pony for Halfling)"});
                    break;
                case "Rogue":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Blather",
                        "Charm",
                        "Evaluate",
                        "Gamble or Secret Signs (Thief)",
                        "Gossip or Haggle",
                        "Perception",
                        "Performer (Actor or Storyteller)",
                        "Search or Secret Language (Thieve's Tongue)"});
                    libTalents.Items.AddRange(new object[] {
                        "Flee! or Streetwise",
                        "Luck or Sixth Sense",
                        "Public Speaking"});
                    libEquipment.Items.AddRange(new object[]{
                        "One set of Best Craftsmanship Clothing",
                        "or Dice",
                        "o Deck of Cards"});
                    careerGold = r.Next(1, 10);
                    break;
                case "Runebearer":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "1";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Dodge Blow",
                        "Navigation",
                        "Outdoor Survival",
                        "Secret Signs (Scout)",
                        "Perception",
                        "Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Flee!",
                        "Fleet Footed or Sixth Sense",
                        "Orientation",
                        "Rapid Reload",
                        "Very Resilient or Very Strong"});
                    libEquipment.Items.AddRange(new object[]{
                        "Crossbow w/ 10 Bolts",
                        "Leather Jerkin",
                        "Healing Draught",
                        "Lucky Charm"});
                    break;
                case "Scribe":
                    txWeaponSkilAdvance.Text = "";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (any one)",
                        "Common Knowledge (the Empire) or Gossip",
                        "Perecption",
                        "Read/Write",
                        "Secret Language (Guild Tongue)",
                        "Speak Language (Breaton)",
                        "Speak Language (Classical)",
                        "Speak Language (Tilean)",
                        "Trade (Caligrapher)"});
                    libTalents.Items.AddRange(new object[] {
                        "Linguistics"});
                    libEquipment.Items.AddRange(new object[]{
                        "Knife",
                        "A Pair of Cangles",
                        "Wax",
                        "5 Matches",
                        "Illuminated Book",
                        "Writing Kit"});
                    break;
                case "Seaman":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "10";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (Bretonnia, Norsca, Tilea, or the Wasteland)",
                        "Consume Alcohol or Perception",
                        "Dodge Blow",
                        "Row",
                        "Sail",
                        "Scale Sheer Surface",
                        "Speak Language (Breaton, Norse, or Tilean)",
                        "Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Hardy or Street Fighting",
                        "Seasoned Traveller",
                        "Strike Mighty Blow or Swashbuckler"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jerkin",
                        "Bottle of Poor Craftsmanship Spirits"});
                    break;
                case "Servant":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animale Care or Trade (Cook)",
                        "Blather",
                        "Dodge Blow",
                        "Drive or Search",
                        "Evaluate or Haggle",
                        "Gossip",
                        "Perception",
                        "Read/Write or Sleight of Hand"});
                    libTalents.Items.AddRange(new object[] {
                        "Acute Hearing or Flee!",
                        "Etiquette or Hardy",
                        "Lightning Reflexes or Very Resilient"});
                    libEquipment.Items.AddRange(new object[]{
                        "One set of Good Crasftsmanship Clothing",
                        "Pewter Tankard",
                        "Tinderbox",
                        "Storm Lantern",
                        "Lamp Oil"});
                    break;
                case "Shieldbreaker":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Dodge Blow",
                        "Navigation",
                        "Perception",
                        "Scale Sheer Surface",
                        "Shadowing"});
                    libTalents.Items.AddRange(new object[] {
                        "Acute Hearing or Coolheaded",
                        "Orientation",
                        "Strike Mighty Blow",
                        "Strike to Injure",
                        "Strike to Stun"});
                    libEquipment.Items.AddRange(new object[]{
                        "Crossbow w/ 10 bolts",
                        "Mail Coat",
                        "Leather Jack",
                        "Leather Leggings",
                        "Shield",
                        "Grappling Hook",
                        "10 Yards of Rope",
                        "Water Skin"});
                    break;
                case "Smuggler":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Drive",
                        "Evaluate",
                        "Gossip or Secret Language (Thieves' Tongue)",
                        "Haggle",
                        "Speak Language (Breton or Kislevian)",
                        "or Secret Signs (Thief)",
                        "Swim"});
                    libTalents.Items.AddRange(new object[] {
                        "Dealmaker or Streetwise"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jack",
                        "2 Torches",
                        "Draft Horse and Cart o Rowing Boat"});
                    break;
                case "Soldier":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care or Heal",
                        "Common Knowledge (the Empire) or Perception",
                        "Dodge Blow",
                        "Drive or Ride",
                        "Gamble or Gossip",
                        "Intimidate"});
                    libTalents.Items.AddRange(new object[] {
                        "Disarm or Quick Draw",
                        "Sharpshooter or Strike Mighty Blow",
                        "Specialist Weapon Group (Gunpowder or Two-handed)",
                        "Strike to Injure or Rapid Reload",
                        "Strike to Stun or Mighty Shoot"});
                    libEquipment.Items.AddRange(new object[]{
                        "Great Weapon (Halberd) or Firearm w/ 10 Shot",
                        "Shield",
                        "Full Leather Armor",
                        "Uniform"});
                    break;
                case "Squire":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (Genalogy/Heraldry)",
                        "or Common Knowledge (Bretonnian)",
                        "Animal Care",
                        "Animal Training",
                        "Charm or Gossip",
                        "Dodge Blow",
                        "Ride",
                        "Speak Language (Breton)"});
                    libTalents.Items.AddRange(new object[] {
                        "Etiquette",
                        "Specialist Weapon Group (Cavalry)",
                        "Strike Mighty Blow"});
                    libEquipment.Items.AddRange(new object[]{
                        "Demilance",
                        "Mail Shirt",
                        "Mail Coif",
                        "Leather Jack",
                        "Shield",
                        "Horse w/ Saddle & Harness"});
                    break;
                case "Student":
                    txWeaponSkilAdvance.Text = "";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (any one)",
                        "Academic Knowledge (any one) or Gossip",
                        "Charm or Consume Alcohol",
                        "Heal or Search",
                        "Perception",
                        "Read/Write",
                        "Speak Language (Classical)"});
                    libTalents.Items.AddRange(new object[] {
                        "Etiquette or Linguistics",
                        "Savvy or Suave",
                        "Seasoned Traveller or Super Numerate"});
                    libEquipment.Items.AddRange(new object[]{
                        "2 Text Books corresponding to Knowledge Skills",
                        "Writing Kit"});
                    break;
                case "Thief":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "15";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Charm or Scale Sheer Surface",
                        "Concealment",
                        "Evaluate or Disguise",
                        "Gamble or Pick Lock",
                        "Perception",
                        "Read/Write or Slight of Hand",
                        "Search",
                        "Secret Language (Thieve's Tongue)",
                        "or Secret Signs (Thief)",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Alley Cat or Streatwise",
                        "Super Numerate or Trapfinder"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jerkin",
                        "Sack",
                        "Lock Picks",
                        "10 Yards of Rope"});
                    break;
                case "Thug":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Consume Alcohol",
                        "Dodge Blow",
                        "Gamble",
                        "Intimidate",
                        "Secret Language (Thieves' Tongue)"});
                    libTalents.Items.AddRange(new object[] {
                        "Coolheaded or Lightning Reflexes",
                        "Disarm",
                        "Resistance to Poison or Quick Draw",
                        "Strike to Injure or Wrestling",
                        "Strike to Stun"});
                    libEquipment.Items.AddRange(new object[]{
                        "Knuckle-dusters",
                        "Mail Shirt",
                        "Leather Jerkin"});
                    break;
                case "Toll Keeper":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "10";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Dodge Blow",
                        "Evaluate",
                        "Gossip or Haggle",
                        "Perception",
                        "Read/Write",
                        "Search",
                        "Speak Language (Breton, Kislevian, or Tilean)"});
                    libTalents.Items.AddRange(new object[] {
                        "Lightning Reflexes or Marksman"});
                    libEquipment.Items.AddRange(new object[]{
                        "Chest",
                        "Crossbow w/ 10 Bolts",
                        "Mail Shirt",
                        "Leather Jerkin",
                        "Shield"});
                    careerGold=r.Next(1,10);
                    break;
                case "Tomb Robber":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (the Empire)",
                        "or Secret Signs (Thief)",
                        "Concealment or Outdoor Survival",
                        "Evaluate",
                        "Perception",
                        "Pick Lock or Silent Move",
                        "Read/Write",
                        "Scale Sheer Surface",
                        "Search",
                        "Speak Language (Classical, Khazalid, or Eltharin)"});
                    libTalents.Items.AddRange(new object[] {
                        "Luck or Sixth Sense",
                        "Trapfinder or Tunnel Rat"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jack",
                        "Crowbar",
                        "Lantern",
                        "Lamp Oil",
                        "10 Yards of Rope",
                        "2 Sacks"});
                    break;
                case "Tradesman":
                    txWeaponSkilAdvance.Text = "";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Animal Care or Gossip",
                        "Drive",
                        "Haggle",
                        "Evaluate",
                        "Perceptio",
                        "Read/Write",
                        "Secret Language (Guild Tongue)",
                        "Trade (any Two)"});
                    libTalents.Items.AddRange(new object[] {
                        "Dealmaker or Savy"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jerkin"});
                    careerGold = r.Next(1,10);
                    break;
                case "Troll Slayer":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "5";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "1";
                    txWoundsAdvance.Text = "3";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Consume Alcohol",
                        "Dodge Blow",
                        "Intimidate"});
                    libTalents.Items.AddRange(new object[] {
                        "Disarm or Quick Draw",
                        "Hardy",
                        "Lightning Reflexes or Very Resilient",
                        "Specialist Weapon Group (Two-handed)",
                        "Street Fighter",
                        "Strike Mighty Blow"});
                    libEquipment.Items.AddRange(new object[]{
                        "Great Weapon",
                        "Leather Jerkin",
                        "One Bottle of Poor Craftsmaship Spirits"});
                    break;
                case "Vagabond":
                    txWeaponSkilAdvance.Text = "5";
                    txBalisticSkilAdvance.Text = "10";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "5";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Common Knowledge (Bretonnia, Estalia, Kislev, or Tilea)",
                        "Gossip or Secret Language (Ranger Tongue or Thieves' Tongue)",
                        "Haggle or Swim",
                        "Heal or Perception",
                        "Navigation",
                        "Outdoor Survival",
                        "Performer (Dancer, Singer, or Storyteller)",
                        "or Secret Signs (Ranger or Thief)",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Fleet Footed or Rover",
                        "Marksman or Orientation",
                        "Seasoned Traveller"});
                    libEquipment.Items.AddRange(new object[]{
                        "Back Pack",
                        "Rations (1 week)",
                        "Tent",
                        "Water Skin"});
                    break;
                case "Valet":
                    txWeaponSkilAdvance.Text = "";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "10";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "5";
                    txFellowAdvance.Text = "10";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (Genalogy/Heraldry)",
                        "Blather",
                        "Evaluate",
                        "Gossip or Speak Language (Breaton)",
                        "Haggle",
                        "Perception",
                        "Read/Write",
                        "Search"});
                    libTalents.Items.AddRange(new object[] {
                        "Coolheaded or Suave",
                        "Dealmaker or Seasoned Traveller",
                        "Etiquette"});
                    libEquipment.Items.AddRange(new object[]{
                        "Cologne",
                        "Purse",
                        "2 sets of Best Craftsmanship Clothing",
                        "Uniform"});
                    break;
                case "Watchman":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "5";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "10";
                    txWillAdvance.Text = "";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (Law)",
                        "Dodge Blow",
                        "Follow Trail",
                        "Gossip",
                        "Intimidate",
                        "Perception",
                        "Search"});
                    libTalents.Items.AddRange(new object[] {
                        "Coolheaded or Savvy",
                        "Disarm or Street Fighting",
                        "Strike Mighty Blow",
                        "Strike to Stun"});
                    libEquipment.Items.AddRange(new object[]{
                        "Leather Jack",
                        "Lantern and Pole",
                        "Lamp Oil",
                        "Uniform"});
                    break;
                case "Woodsman":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "10";
                    txToughnesAdvance.Text = "";
                    txAgilityAdvance.Text = "5";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "3";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Concealment",
                        "Follow Trail or Set Trap",
                        "Perception",
                        "Scale Sheer Surface",
                        "Secret Language (Ranger Tongue)",
                        "Secret Signs (Ranger)",
                        "Silent Move"});
                    libTalents.Items.AddRange(new object[] {
                        "Fleet Footed or Very Resilient",
                        "Rover",
                        "Specialist Weapon Group (Two-handed)"});
                    libEquipment.Items.AddRange(new object[]{
                        "Great Weapon (Two-handed Axe)",
                        "Leather Jack",
                        "Antitoxin Kit"});
                    break;
                case "Zealot":
                    txWeaponSkilAdvance.Text = "10";
                    txBalisticSkilAdvance.Text = "";
                    txStrentghAdvance.Text = "5";
                    txToughnesAdvance.Text = "10";
                    txAgilityAdvance.Text = "";
                    txIntAdvance.Text = "";
                    txWillAdvance.Text = "10";
                    txFellowAdvance.Text = "5";
                    txAttacksAdvance.Text = "";
                    txWoundsAdvance.Text = "2";
                    txStrBonusAdvance.Text = "";
                    txToughBonusAdvance.Text = "";
                    txMoveAdvance.Text = "";
                    txMagicAdvance.Text = "";
                    txInsanityAdvance.Text = "";
                    txFateAdvance.Text = "";

                    libSkills.Items.AddRange(new object[] {
                        "Academic Knowledge (Theology)",
                        "Charm",
                        "Common Knowledge (the Empire)",
                        "Intimidate",
                        "Read/Write"});
                    libTalents.Items.AddRange(new object[] {
                        "Coolheaded or Very Strong",
                        "Heardy or Suave",
                        "Public Speaking",
                        "Specialist Weapon Group (Flail)"});
                    libEquipment.Items.AddRange(new object[]{
                        "Flail or Morning Star",
                        "Leather Jack",
                        "Bottle of Good Craftsmanship Spirits"});
                    break;
            }

            txGold.Text = Convert.ToString(startingGold + careerGold);
        }

        public string randomTalent()
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
                    { tallent = randTallents[0]; }
                    else if (roll >= 6 && roll <= 10)
                    { tallent = randTallents[1]; }
                    else if (roll >= 11 && roll <= 15)
                    { tallent = randTallents[2]; }
                    else if (roll >= 16 && roll <= 20)
                    { tallent = randTallents[3]; }
                    else if (roll >= 21 && roll <= 25)
                    { tallent = randTallents[4]; }
                    else if (roll >= 26 && roll <= 29)
                    { tallent = randTallents[5]; }
                    else if (roll >= 30 && roll <= 33)
                    { tallent = randTallents[6]; }
                    else if (roll >= 34 && roll <= 38)
                    { tallent = randTallents[7]; }
                    else if (roll >= 39 && roll <= 42)
                    { tallent = randTallents[8]; }
                    else if (roll >= 43 && roll <= 47)
                    { tallent = randTallents[9]; }
                    else if (roll >= 48 && roll <= 51)
                    { tallent = randTallents[11]; }
                    else if (roll >= 52 && roll <= 53)
                    { tallent = randTallents[12]; }
                    else if (roll >= 54 && roll <= 57)
                    { tallent = randTallents[13]; }
                    else if (roll >= 58 && roll <= 62)
                    { tallent = randTallents[14]; }
                    else if (roll >= 63 && roll <= 67)
                    { tallent = randTallents[15]; }
                    else if (roll >= 68 && roll <= 72)
                    { tallent = randTallents[16]; }
                    else if (roll >= 73 && roll <= 77)
                    { tallent = randTallents[17]; }
                    else if (roll >= 78 && roll <= 82)
                    { tallent = randTallents[18]; }
                    else if (roll >= 83 && roll <= 87)
                    { tallent = randTallents[19]; }
                    else if (roll >= 88 && roll <= 91)
                    { tallent = randTallents[20]; }
                    else if (roll >= 92 && roll <= 95)
                    { tallent = randTallents[21]; }
                    else if (roll >= 96 && roll <= 100)
                    { tallent = randTallents[22]; }
                    break;
                case 3:
                    if (roll >= 1 && roll <= 4)
                    { tallent = randTallents[0]; }
                    else if (roll >= 5 && roll <= 9)
                    { tallent = randTallents[1]; }
                    else if (roll >= 10 && roll <= 13)
                    { tallent = randTallents[2]; }
                    else if (roll >= 14 && roll <= 18)
                    { tallent = randTallents[3]; }
                    else if (roll >= 19 && roll <= 22)
                    { tallent = randTallents[4]; }
                    else if (roll >= 23 && roll <= 27)
                    { tallent = randTallents[5]; }
                    else if (roll >= 28 && roll <= 31)
                    { tallent = randTallents[6]; }
                    else if (roll >= 32 && roll <= 35)
                    { tallent = randTallents[7]; }
                    else if (roll >= 36 && roll <= 40)
                    { tallent = randTallents[8]; }
                    else if (roll >= 41 && roll <= 44)
                    { tallent = randTallents[9]; }
                    else if (roll >= 45 && roll <= 49)
                    { tallent = randTallents[10]; }
                    else if (roll >= 50 && roll <= 53)
                    { tallent = randTallents[11]; }
                    else if (roll >= 54 && roll <= 57)
                    { tallent = randTallents[12]; }
                    else if (roll >= 58 && roll <= 61)
                    { tallent = randTallents[13]; }
                    else if (roll >= 62 && roll <= 66)
                    { tallent = randTallents[14]; }
                    else if (roll >= 67 && roll <= 71)
                    { tallent = randTallents[15]; }
                    else if (roll >= 72 && roll <= 75)
                    { tallent = randTallents[16]; }
                    else if (roll >= 76 && roll <= 79)
                    { tallent = randTallents[17]; }
                    else if (roll >= 80 && roll <= 83)
                    { tallent = randTallents[18]; }
                    else if (roll >= 84 && roll <= 87)
                    { tallent = randTallents[19]; }
                    else if (roll >= 88 && roll <= 91)
                    { tallent = randTallents[20]; }
                    else if (roll >= 92 && roll <= 95)
                    { tallent = randTallents[21]; }
                    else if (roll >= 96 && roll <= 100)
                    { tallent = randTallents[22]; }
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
