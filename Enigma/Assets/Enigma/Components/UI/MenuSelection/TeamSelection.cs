﻿using Assets.Enigma.Components.Base_Classes.TeamSettings.Enums;
using Assets.Enigma.Components.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Enigma.Components.UI.MenuSelection
{
    public class TeamSelection : MonoBehaviour
    {
        public GameObject UIObject;
        public NetworkManagerExtension NetworkManagerExtension;

        void Start()
        {
            HideMenu();
        }

        void Update()
        {
            if (Input.GetButtonDown("General_TeamSelection"))
            {
                ToggleMenu();
            }
        }

        public void SelectTeam1()
        {
            TeamSelected(TeamName.Team_1_People);
        }

        public void SelectTeam2()
        {
            TeamSelected(TeamName.Team_2_TheOrder);
        }

        private void TeamSelected(TeamName teamName)
        {
            HideMenu();
            NetworkManagerExtension.SpawnPlayer(teamName);
        }

        public void ShowMenu()
        {
            UIObject.SetActive(true);
        }

        public void HideMenu()
        {
            UIObject.SetActive(false);
        }

        private void ToggleMenu()
        {
            if (UIObject.activeSelf == false)
            {
                ShowMenu();
            }
            else
            {
                HideMenu();
            }
        }
    }
}