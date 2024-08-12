﻿using ModCore;
using System.IO;
using UnityEngine;

namespace ArchipelagoRandomizer
{
    public class TestCommand
    {
        private static TestCommand instance;
        public static TestCommand Instance { get { return instance; } }

        private string[] crystalEdgeRimRamps =
        {
            "ChestCrystalRimGold",
            "ChestCrystalRimGold",
            "ChestCrystalRimSilver",
            "ChestCrystalRimSilver",
            "ChestCrystalRimSilver",
            "ChestCrystalRimGold",
            "ChestCrystalRimSilver",
            "ChestCrystalRimGold"
        };
        private string[] crystalEdgeRims =
        {
            "ChestJewelGold",
            "ChestJewelGold",
            "ChestJewelSilver",
            "ChestJewelSilver",
            "ChestJewelSilver",
            "ChestJewelGold",
            "ChestJewelSilver",
            "ChestJewelGold"
        };
        private string[] crystalFaceRamps =
        {
            "ChestJewelGreen",
            "ChestJewelBrown",
            "ChestJewelBurgundy",
            "ChestJewelDarkGrey",
            "ChestJewelGreen",
            "ChestJewelBlue",
            "ChestJewelOrange",
            "ChestJewelOrange"
        };
        private string[] crystalFaceRims =
        {
            "ChestCrystalRimGreen",
            "ChestCrystalRimBrown",
            "ChestCrystalRimBurgundy",
            "ChestCrystalRimDarkGrey",
            "ChestCrystalRimGreen",
            "ChestCrystalRimBlue",
            "ChestCrystalRimOrange",
            "ChestCrystalRimOrange"
        };
        private string[] crystalEdgeColors =
        {
            "ChestYellow",
            "ChestYellow",
            "ChestLightGrey",
            "ChestLightGrey",
            "ChestLightGrey",
            "ChestYellow",
            "ChestLightGrey",
            "ChestYellow"
        };
        // Crystal edges
        private Material edgeMaterial;
        // Crystal faces
        private Material faceMaterial;

        public TestCommand()
        {
            instance = this;
        }

        public void AddCommands()
        {
            DebugMenuManager.AddCommands(this);
        }

        [DebugMenuCommand(commandName:"test")]
        private void SendTestCommand(string[] args)
        {
            if (edgeMaterial == null)
            {
                Renderer chestRenderer = GameObject.Find("Dungeon_PuzzleChest").transform.Find("crystal").GetComponent<Renderer>();
                edgeMaterial = chestRenderer.sharedMaterials[1];
                faceMaterial = chestRenderer.sharedMaterials[0];
            }
            if (args.Length > 0)
            {
                if (int.TryParse(args[0], out int id))
                {
                    edgeMaterial.shader = Shader.Find("Unlit/Texture");
                    edgeMaterial.SetTexture("_MainTex", ModCore.Utility.GetTextureFromFile($"{PluginInfo.PLUGIN_NAME}/Assets/{crystalEdgeColors[id]}.png"));
                    edgeMaterial.SetTexture("_RampTex", ModCore.Utility.GetTextureFromFile($"{PluginInfo.PLUGIN_NAME}/Assets/{crystalEdgeRims[id]}.png"));
                    edgeMaterial.SetTexture("_RimRamp", ModCore.Utility.GetTextureFromFile($"{PluginInfo.PLUGIN_NAME}/Assets/{crystalEdgeRimRamps[id]}.png"));

                    // rimMaterial.SetTexture("_RimRamp", ModCore.Utility.GetTextureFromFile($"{PluginInfo.PLUGIN_NAME}/Assets/{rimColors[id]}.png"));
                    faceMaterial.SetTexture("_SpecularRamp", ModCore.Utility.GetTextureFromFile($"{PluginInfo.PLUGIN_NAME}/Assets/{crystalFaceRims[id]}.png"));
                    faceMaterial.SetTexture("_RimRamp", ModCore.Utility.GetTextureFromFile($"{PluginInfo.PLUGIN_NAME}/Assets/{crystalFaceRamps[id]}.png"));
                    //rimMaterial.SetTexture("_SpecularRamp", ModCore.Utility.GetTextureFromFile($"{PluginInfo.PLUGIN_NAME}/Assets/{rimShines[id]}.png"));
                    //chestMaterial.SetTexture("_MainTex", ModCore.Utility.GetTextureFromFile($"{PluginInfo.PLUGIN_NAME}/Assets/{chestColors[id]}.png"));
                }
            }
        }
    }
}
