﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Enigma.Components.UI;
using Assets.Enigma.Components.Base_Classes.Buildings;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Assets.Enigma.Components.UI.Commander;
using Assets.Enigma.Components.Base_Classes.TeamSettings.Resources;

namespace Assets.Enigma.Components.UI.Buildings
{
    public class ButtonBuilding : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public BuildingHologram buildingHologram;
        protected UICommander uICommander;
        private Image buttonImage;

        protected BuildingStats stats;

        private static Color colorAfford = Color.white;
        private static Color colorTooLow = Color.red;

        private Color colorTextMoney;
        private Color colorTextOil;

        private bool isHighLighted = false;

        private AudioSource soundCantAfford;


        // Use this for initialization
        void Start()
        {
            buttonImage = GetComponent<Button>().GetComponent<Image>();
            uICommander = GetComponentInParent<UICommander>();
            soundCantAfford = GetComponentInParent<AudioSource>();
            Init();
        }

        /// <summary>
        /// To be called from the children who inheritance from this class.
        /// </summary>
        protected virtual void Init()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isHighLighted)
            {
                CheckResources();
            }
        }

        public void Click()
        {
            if (colorTextMoney == colorAfford && colorTextOil == colorAfford)
            {
                uICommander.BuildingPlacement.SetSelectedHologram(buildingHologram);
            }
            else
            {
                if (soundCantAfford != null && soundCantAfford.isPlaying == false)
                {
                    soundCantAfford.Play();
                }
            }
        }
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            buttonImage.color = Color.gray;
            isHighLighted = true;
            uICommander.Tooltip.ShowTooltip(stats, colorTextMoney, colorTextOil);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            buttonImage.color = Color.white;
            isHighLighted = false;
        }

        private void CheckResources()
        {
            var resources = uICommander.ResourceManager.GetResources();
            CheckMoney(resources.First);
            CheckOil(resources.Second);
            uICommander.Tooltip.UpdateColors(colorTextMoney, colorTextOil);
        }

        private void CheckMoney(Money current)
        {
            if (stats.costMoney <= current.Current)
            {
               colorTextMoney = colorAfford;
            }
            else
            {
                colorTextMoney = colorTooLow;
            }
        }

        private void CheckOil(Oil current)
        {
            if (stats.costOil <= current.Current)
            {
                colorTextOil = colorAfford;
            }
            else
            {
                colorTextOil = colorTooLow;
            }
        }
    }
}