﻿using FrooxEngine;
using FrooxEngine.UIX;
using HarmonyLib;
using NeosModLoader;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace DefaultTooltips
{
    public class DefaultTooltips : NeosMod
    {
        public override string Name => "DefaultTooltips";
        public override string Author => "Psychpsyo";
        public override string Version => "1.1.0";
        public override string Link => "https://github.com/Psychpsyo/DefaultTooltips";

        private static Dictionary<string, string> localeStrings;

        // loads the text for all tooltips from locale files.
        // English is an implicit fallback for when keys don't exist in other languages
        private void loadLabelText()
        {
            // load English labels
            localeStrings = JsonSerializer.Deserialize<Dictionary<string, string>>(System.IO.File.ReadAllText(@"./nml_mods/defaultTooltips/locales/en.json"));
            // load localized labels
            string language;
            Settings.TryReadValue("Interface.Locale", out language);
            try
            {
                Dictionary<string, string> userLang = JsonSerializer.Deserialize<Dictionary<string, string>>(System.IO.File.ReadAllText(@"./nml_mods/defaultTooltips/locales/" + language + ".json"));
                userLang.ToList().ForEach(label => localeStrings[label.Key] = label.Value);
            }
            catch { }
        }

        public override void OnEngineInit()
        {
            Settings.RegisterListener("Interface.Locale", loadLabelText, true);

            // add label providers to Tooltippery mod
            Tooltippery.Tooltippery.labelProviders.Add(inspectorLabels);
            Tooltippery.Tooltippery.labelProviders.Add(inventoryLabels);
            Tooltippery.Tooltippery.labelProviders.Add(contactsDialogLabels);
            Tooltippery.Tooltippery.labelProviders.Add(sessionControlLabels);
            Tooltippery.Tooltippery.labelProviders.Add(settingsDialogLabels);
            Tooltippery.Tooltippery.labelProviders.Add(voiceFacetLabels);
            Tooltippery.Tooltippery.labelProviders.Add(createNewLabels);
            Tooltippery.Tooltippery.labelProviders.Add(fileBrowserLabels);
            Tooltippery.Tooltippery.labelProviders.Add(imageImportLabels);
            Tooltippery.Tooltippery.labelProviders.Add(videoImportLabels);
            Tooltippery.Tooltippery.labelProviders.Add(modelImportLabels);
            Tooltippery.Tooltippery.labelProviders.Add(avatarCreatorLabels);
            Tooltippery.Tooltippery.labelProviders.Add(onlineStatusFacetLabels);
            Tooltippery.Tooltippery.labelProviders.Add(worldCloseButtonLabels);
            Tooltippery.Tooltippery.labelProviders.Add(dashExitLabels);
            Tooltippery.Tooltippery.labelProviders.Add(audioStreamLabels);
            Tooltippery.Tooltippery.labelProviders.Add(coreWorldsLabels);
            Tooltippery.Tooltippery.labelProviders.Add(profileFacetLabels);
            Tooltippery.Tooltippery.labelProviders.Add(toolsFacetLabels);
            Tooltippery.Tooltippery.labelProviders.Add(debugPanelLabels);
            Tooltippery.Tooltippery.labelProviders.Add(assortedFacetLabels);
            Tooltippery.Tooltippery.labelProviders.Add(nameplateVisibilityLabels);
        }

        private static Dictionary<string, string> createNewLabelDict = new Dictionary<string, string>()
        {
            {"", "general.back"},
            {"/0", "createNew.emptyObject"},
            {"/1", "createNew.particleSystem"},
            {"/3DModel", "createNew.3DModelMenu"},
            {"/3DModel/0", "createNew.3DModel.box"},
            {"/3DModel/1", "createNew.3DModel.capsule"},
            {"/3DModel/2", "createNew.3DModel.cone"},
            {"/3DModel/3", "createNew.3DModel.cylinder"},
            {"/3DModel/4", "createNew.3DModel.grid"},
            {"/3DModel/5", "createNew.3DModel.quad"},
            {"/3DModel/6", "createNew.3DModel.sphere"},
            {"/3DModel/7", "createNew.3DModel.torus"},
            {"/3DModel/8", "createNew.3DModel.triangle"},
            {"/Collider", "createNew.colliderMenu"},
            {"/Collider/0", "createNew.collider.box"},
            {"/Collider/1", "createNew.collider.capsule"},
            {"/Collider/2", "createNew.collider.cone"},
            {"/Collider/3", "createNew.collider.cylinder"},
            {"/Collider/4", "createNew.collider.mesh"},
            {"/Collider/5", "createNew.collider.sphere"},
            {"/Editor", "createNew.editorMenu"},
            {"/Editor/0", "createNew.editor.assetOptimizationWizard"},
            {"/Editor/1", "createNew.editor.cubemapCreator"},
            {"/Editor/2", "createNew.editor.worldLightSourcesWizard"},
            {"/Editor/3", "createNew.editor.logixTransferWizard"},
            {"/Editor/4", "createNew.editor.reflectionProbeWizard"},
            {"/Editor/5", "createNew.editor.worldTextRendererWizard"},
            {"/Editor/6", "createNew.editor.userInspector"},
            {"/Light", "createNew.lightMenu"},
            {"/Light/0", "createNew.light.directional"},
            {"/Light/1", "createNew.light.point"},
            {"/Light/2", "createNew.light.spot"},
            {"/Materials", "createNew.materialMenu"},
            {"/Materials/Filters", "createNew.materials.filtersMenu"},
            {"/Materials/Filters/0", "createNew.materials.filters.blur"},
            {"/Materials/Filters/1", "createNew.materials.filters.channelMatrix"},
            {"/Materials/Filters/2", "createNew.materials.filters.depth"},
            {"/Materials/Filters/3", "createNew.materials.filters.gamma"},
            {"/Materials/Filters/4", "createNew.materials.filters.grayscale"},
            {"/Materials/Filters/5", "createNew.materials.filters.HSV"},
            {"/Materials/Filters/6", "createNew.materials.filters.invert"},
            {"/Materials/Filters/7", "createNew.materials.filters.LUT"},
            {"/Materials/Filters/8", "createNew.materials.filters.pixelate"},
            {"/Materials/Filters/9", "createNew.materials.filters.posterize"},
            {"/Materials/Filters/10", "createNew.materials.filters.refract"},
            {"/Materials/Filters/11", "createNew.materials.filters.threshold"},
            {"/Materials/PBS", "createNew.materials.pbsMenu"},
            {"/Materials/PBS/0", "createNew.materials.pbs.pbsColorMaskMetallic"},
            {"/Materials/PBS/1", "createNew.materials.pbs.pbsColorMaskSpecular"},
            {"/Materials/PBS/2", "createNew.materials.pbs.pbsColorSplatMetallic"},
            {"/Materials/PBS/3", "createNew.materials.pbs.pbsColorSplatSpecular"},
            {"/Materials/PBS/4", "createNew.materials.pbs.pbsDistanceMetallic"},
            {"/Materials/PBS/5", "createNew.materials.pbs.pbsDistanceSpecular"},
            {"/Materials/PBS/6", "createNew.materials.pbs.pbsDistanceLerpMetallic"},
            {"/Materials/PBS/7", "createNew.materials.pbs.pbsDistanceLerpSpecular"},
            {"/Materials/PBS/8", "createNew.materials.pbs.pbsDualSidedMetallic"},
            {"/Materials/PBS/9", "createNew.materials.pbs.pbsDualSidedSpecular"},
            {"/Materials/PBS/10", "createNew.materials.pbs.pbsIntersectMetallic"},
            {"/Materials/PBS/11", "createNew.materials.pbs.pbsIntersectSpecular"},
            {"/Materials/PBS/12", "createNew.materials.pbs.pbsMultiUVMetallic"},
            {"/Materials/PBS/13", "createNew.materials.pbs.pbsMultiUVSpecular"},
            {"/Materials/PBS/14", "createNew.materials.pbs.pbsRimMetallic"},
            {"/Materials/PBS/15", "createNew.materials.pbs.pbsRimSpecular"},
            {"/Materials/PBS/16", "createNew.materials.pbs.pbsSliceMetallic"},
            {"/Materials/PBS/17", "createNew.materials.pbs.pbsSliceSpecular"},
            {"/Materials/PBS/18", "createNew.materials.pbs.pbsStencilMetallic"},
            {"/Materials/PBS/19", "createNew.materials.pbs.pbsStencilSpecular"},
            {"/Materials/PBS/20", "createNew.materials.pbs.pbsTriplanarMetallic"},
            {"/Materials/PBS/21", "createNew.materials.pbs.pbsTriplanarSpecular"},
            {"/Materials/PBS/22", "createNew.materials.pbs.pbsVertexColorMetallic"},
            {"/Materials/PBS/23", "createNew.materials.pbs.pbsVertexColorSpecular"},
            {"/Materials/PBS/24", "createNew.materials.pbs.pbsVoronoiCrystal"},
            {"/Materials/PBS/25", "createNew.materials.pbs.pbsLerpMetallic"},
            {"/Materials/PBS/26", "createNew.materials.pbs.pbsLerpSpecular"},
            {"/Materials/Skybox", "createNew.materials.skyboxMenu"},
            {"/Materials/Skybox/0", "createNew.materials.skybox.gradientSky"},
            {"/Materials/Skybox/1", "createNew.materials.skybox.proceduralSky"},
            {"/Materials/Special", "createNew.materials.specialMenu"},
            {"/Materials/Special/0", "createNew.materials.special.debug"},
            {"/Materials/Special/1", "createNew.materials.special.reflection"},
            {"/Materials/Special/2", "createNew.materials.special.uvRect"},
            {"/Materials/text", "createNew.materials.textMenu"},
            {"/Materials/text/0", "createNew.materials.text.textUnlit"},
            {"/Materials/UI", "createNew.materials.uiMenu"},
            {"/Materials/UI/Circle Segment", "createNew.materials.ui.circleSegmentMenu"},
            {"/Materials/UI/Circle Segment/0", "createNew.materials.ui.circleSegment.uiCircleSegment"},
            {"/Materials/UI/Text", "createNew.materials.ui.textMenu"},
            {"/Materials/UI/Text/0", "createNew.materials.ui.text.uiTextUnlit"},
            {"/Materials/UI/0", "createNew.materials.ui.uiUnlit"},
            {"/Materials/Unlit", "createNew.materials.unlitMenu"},
            {"/Materials/Unlit/0", "createNew.materials.unlit.depthProjection"},
            {"/Materials/Unlit/1", "createNew.materials.unlit.fresnel"},
            {"/Materials/Unlit/2", "createNew.materials.unlit.fresnelLerp"},
            {"/Materials/Unlit/3", "createNew.materials.unlit.matcap"},
            {"/Materials/Unlit/4", "createNew.materials.unlit.overlayFresnel"},
            {"/Materials/Unlit/5", "createNew.materials.unlit.overlayUnlit"},
            {"/Materials/Unlit/6", "createNew.materials.unlit.projection360"},
            {"/Materials/Unlit/7", "createNew.materials.unlit.unlit"},
            {"/Materials/Unlit/8", "createNew.materials.unlit.unlitDistanceLerp"},
            {"/Materials/Unlit/9", "createNew.materials.unlit.wireframe"},
            {"/Materials/Volume", "createNew.materials.volumeMenu"},
            {"/Materials/Volume/0", "createNew.materials.volume.fogBoxVolume"},
            {"/Materials/Volume/1", "createNew.materials.volume.volumeUnlit"},
            {"/Materials/0", "createNew.materials.fur"},
            {"/Materials/1", "createNew.materials.pbsMetallic"},
            {"/Materials/2", "createNew.materials.pbsSpecular"},
            {"/Materials/3", "createNew.materials.xiexeToon"},
            {"/Object", "createNew.objectMenu"},
            {"/Object/FogVolume", "createNew.object.fogVolumeMenu"},
            {"/Object/FogVolume/0", "createNew.object.fogVolume.additive"},
            {"/Object/FogVolume/1", "createNew.object.fogVolume.alpha"},
            {"/Object/FogVolume/2", "createNew.object.fogVolume.gradient"},
            {"/Object/FogVolume/3", "createNew.object.fogVolume.multiplicative"},
            {"/Object/Neos UI", "createNew.object.neosUIMenu"},
            {"/Object/Neos UI/Color Dialog", "createNew.object.neosUI.colorDialogMenu"},
            {"/Object/Neos UI/Color Dialog/0", "createNew.object.neosUI.colorDialog.HDR"},
            {"/Object/Neos UI/Color Dialog/1", "createNew.object.neosUI.colorDialog.HDRA"},
            {"/Object/Neos UI/Color Dialog/2", "createNew.object.neosUI.colorDialog.RGB"},
            {"/Object/Neos UI/Color Dialog/3", "createNew.object.neosUI.colorDialog.RGBA"},
            {"/Object/Neos UI/0", "createNew.object.neosUI.button"},
            {"/Object/Neos UI/1", "createNew.object.neosUI.checkbox"},
            {"/Object/Neos UI/2", "createNew.object.neosUI.horizontalChoiceBar"},
            {"/Object/Neos UI/3", "createNew.object.neosUI.numericUpDown"},
            {"/Object/Neos UI/4", "createNew.object.neosUI.panel"},
            {"/Object/Neos UI/5", "createNew.object.neosUI.progressBar"},
            {"/Object/Neos UI/6", "createNew.object.neosUI.radio"},
            {"/Object/Neos UI/7", "createNew.object.neosUI.slider"},
            {"/Object/Neos UI/8", "createNew.object.neosUI.textField"},
            {"/Object/0", "createNew.object.avatarCreator"},
            {"/Object/1", "createNew.object.camera"},
            {"/Object/2", "createNew.object.facet"},
            {"/Object/3", "createNew.object.mirror"},
            {"/Object/4", "createNew.object.portal"},
            {"/Object/5", "createNew.object.reflectionProbe"},
            {"/Object/6", "createNew.object.spawnArea"},
            {"/Object/7", "createNew.object.spawnPoint"},
            {"/Object/8", "createNew.object.canvas"},
            {"/Object/9", "createNew.object.videoPlayer"},
            {"/Text", "createNew.textMenu"},
            {"/Text/0", "createNew.text.Basic"},
            {"/Text/1", "createNew.text.Outline"}
        };
        private static string createNewLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<DevCreateNewForm>() == null) return null;
            string target = button.Slot.GetComponent<ButtonRelay<string>>()?.Argument.Value;
            if (target == null) return null;
            if (createNewLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static Dictionary<string, string> inspectorLabelDict = new Dictionary<string, string>()
        {
            {"OnObjectRootPressed", "inspector.objectRoot"},
            {"OnRootUpPressed", "inspector.hierarchyUp"},
            {"OnDestroyPressed", "inspector.destroySlot"},
            {"OnDestroyPreservingAssetsPressed", "inspector.destroyPreserveAssets"},
            {"OnInsertParentPressed", "inspector.insertParent"},
            {"OnAddChildPressed", "inspector.addChild"},
            {"OnDuplicatePressed", "inspector.duplicateSlot"},
            {"OnSetRootPressed", "inspector.focusHierarchyHere"},
            {"OnAttachComponentPressed", "inspector.attachComponent"}
        };
        private static string inspectorLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            // get the inspector and target method of the button
            SceneInspector inspector = button.Slot.GetComponentInParents<SceneInspector>();
            if (inspector == null) return null;

            WorldDelegate? buttonTarget = null;
            if (((Button)button).Pressed?.Target != null) buttonTarget = ((Button)button).Pressed.Value;
            if (button.Slot.GetComponent<ButtonRelay>()?.ButtonPressed?.Target != null) buttonTarget = button.Slot.GetComponent<ButtonRelay>()?.ButtonPressed?.Value;
            if (!buttonTarget.HasValue) return null;

            string methodName = buttonTarget.Value.method;

            // is this button is calling a function of the inspector itself?
            if (buttonTarget.Value.target == inspector.ReferenceID)
            {
                string retVal;
                if (inspectorLabelDict.TryGetValue(methodName, out retVal)) return localeStrings[retVal];
            }

            return null;
        }


        private static Dictionary<string, string> inventoryLabelDict = new Dictionary<string, string>()
        {
            {"ShowInventoryOwners", "inventory.groups"},
            {"GenerateLink", "inventory.spawnFolder"},
            {"MakePrivate", "inventory.makePrivate"},
            {"DeleteItem", "inventory.delete"},
            {"AddCurrentAvatar", "inventory.saveAvatar"},
            {"AddNew", "inventory.addNew"},
            {"OnOpenWorld", "inventory.openWorld"},
            {"OnEquipAvatar", "inventory.equipAvatar"},
            {"OnSetDefaultHome", "inventory.favHome"},
            {"OnSetDefaultAvatar", "inventory.favAvatar"},
            {"OnSetDefaultKeyboard", "inventory.favKeyboard"},
            {"OnSetDefaultCamera", "inventory.favCamera"},
            {"OnSpawnFacet", "inventory.spawnFacet"}
        };
        private static string inventoryLabels(IButton button, ButtonEventData eventData)
        {
            InventoryBrowser inventory = button.Slot.GetComponentInParents<InventoryBrowser>();
            if (inventory == null) return null;

            WorldDelegate? buttonTarget = null;
            if (((Button)button).Pressed?.Target != null)
            {
                buttonTarget = ((Button)button).Pressed.Value;
            }
            else if (button.Slot.GetComponent<ButtonRelay>()?.ButtonPressed?.Target != null)
            {
                buttonTarget = button.Slot.GetComponent<ButtonRelay>().ButtonPressed.Value;
            }
            // back buttons
            else if (button.Slot.GetComponent<ButtonRelay<int>>()?.ButtonPressed?.Target != null)
            {
                ButtonRelay<int> relay = button.Slot.GetComponent<ButtonRelay<int>>();
                buttonTarget = relay.ButtonPressed?.Value;
                if (!buttonTarget.HasValue) return null;
                if (buttonTarget.Value.method == "OnGoUp")
                {
                    string[] path = inventory.CurrentPath == "" ? new[] { "Inventory" } : ("Inventory\\" + inventory.CurrentPath).Split('\\');
                    return localeStrings["general.goBackTo"].Replace("{{FOLDER}}", path[path.Length - 1 - relay.Argument]);
                }
                else
                {
                    return null;
                }
            }
            if (!buttonTarget.HasValue) return null;

            string methodName = buttonTarget.Value.method;

            // is this button is calling a function of the inspector itself?
            if (buttonTarget.Value.target == inventory.ReferenceID)
            {
                string retVal;
                if (inventoryLabelDict.TryGetValue(methodName, out retVal)) return localeStrings[retVal];
            }

            return null;
        }


        private static Dictionary<VoiceMode, string> voiceFacetLabelDict = new Dictionary<VoiceMode, string>()
        {
            {VoiceMode.Whisper, "voiceModes.whisper"},
            {VoiceMode.Normal, "voiceModes.normal"},
            {VoiceMode.Shout, "voiceModes.shout"},
            {VoiceMode.Broadcast, "voiceModes.broadcast"},
        };
        private static string voiceFacetLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<VoiceFacetPreset>() == null) return null;
            VoiceMode? targetVoiceMode = button.Slot.GetComponent<ButtonValueSet<VoiceMode>>()?.SetValue.Value;
            if (!targetVoiceMode.HasValue)
            {
                IField<bool> targetToggle = button.Slot.GetComponent<ButtonToggle>()?.TargetValue.Target;
                if (targetToggle?.Name == "GlobalMute")
                {
                    return targetToggle.Value ? localeStrings["voiceModes.unmute"] : localeStrings["voiceModes.mute"];
                }
                return null;
            }

            return localeStrings[voiceFacetLabelDict[targetVoiceMode.Value]];
        }


        private static Dictionary<CloudX.Shared.OnlineStatus, string> onlineStatusFacetLabelDict = new Dictionary<CloudX.Shared.OnlineStatus, string>()
        {
            {CloudX.Shared.OnlineStatus.Online, "onlineStatus.online"},
            {CloudX.Shared.OnlineStatus.Away, "onlineStatus.away"},
            {CloudX.Shared.OnlineStatus.Busy, "onlineStatus.busy"},
            {CloudX.Shared.OnlineStatus.Invisible, "onlineStatus.invisible"},
        };
        private static string onlineStatusFacetLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<OnlineStatusFacetPreset>() == null) return null;
            CloudX.Shared.OnlineStatus? targetStatus = button.Slot.GetComponent<ButtonValueSet<CloudX.Shared.OnlineStatus>>()?.SetValue.Value;
            if (!targetStatus.HasValue) return null;

            string retVal = null;
            onlineStatusFacetLabelDict.TryGetValue(targetStatus.Value, out retVal);
            return localeStrings[retVal];
        }


        private static Dictionary<string, string> fileBrowserLabelDict = new Dictionary<string, string>()
        {
            {"RunImport", "fileBrowser.import"},
            {"RunRawImport", "fileBrowser.importRaw"},
            {"CreateNew", "fileBrowser.addNew"},
            {"Reload", "fileBrowser.refresh"}
        };
        private static string fileBrowserLabels(IButton button, ButtonEventData eventData)
        {
            FileBrowser fileBrowser = button.Slot.GetComponentInParents<FileBrowser>();
            if (fileBrowser == null) return null;

            WorldDelegate? buttonTarget = null;
            if (((Button)button).Pressed?.Target != null)
            {
                buttonTarget = ((Button)button).Pressed.Value;
            }
            else if (button.Slot.GetComponent<ButtonRelay>()?.ButtonPressed?.Target != null)
            {
                buttonTarget = button.Slot.GetComponent<ButtonRelay>().ButtonPressed.Value;
            }
            // back buttons
            else if (button.Slot.GetComponent<ButtonRelay<int>>()?.ButtonPressed?.Target != null)
            {
                ButtonRelay<int> relay = button.Slot.GetComponent<ButtonRelay<int>>();
                buttonTarget = relay.ButtonPressed?.Value;
                if (!buttonTarget.HasValue) return null;
                if (buttonTarget.Value.method == "OnGoUp")
                {
                    string[] path = fileBrowser.CurrentPath == null ? new[] { "Computer" } : ("Computer\\" + fileBrowser.CurrentPath).Split('\\');
                    return localeStrings["general.goBackTo"].Replace("{{FOLDER}}", path[path.Length - 1 - relay.Argument]);
                }
                else
                {
                    return null;
                }
            }
            if (!buttonTarget.HasValue) return null;

            string methodName = buttonTarget.Value.method;

            // is this button is calling a function of the inspector itself?
            if (buttonTarget.Value.target == fileBrowser.ReferenceID)
            {
                string retVal;
                if (fileBrowserLabelDict.TryGetValue(methodName, out retVal)) return localeStrings[retVal];
            }

            return null;
        }


        private static Dictionary<string, string> imageImportLabelDict = new Dictionary<string, string>()
        {
            {"Return", "general.back"},
            {"Preset_Image", "imageImport.image"},
            {"Preset_Screenshot", "imageImport.screenshot"},
            {"Preset_360", "imageImport.360"},
            {"Preset_StereoImage", "imageImport.stereo"},
            {"Preset_Stereo360", "imageImport.stereo360"},
            {"Preset_180", "imageImport.180"},
            {"Preset_Stereo180", "imageImport.stereo180"},
            {"Preset_LUT", "imageImport.LUT"},
            {"AsRawFile", "general.rawFileImport"},
            {"Preset_HorizontalLR", "imageImport.stereo.horizontalLR"},
            {"Preset_HorizontalRL", "imageImport.stereo.horizontalRL"},
            {"Preset_VerticalLR", "imageImport.stereo.verticalLR"},
            {"Preset_VerticalRL", "imageImport.stereo.verticalRL"}
        };
        private static string imageImportLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            if (button.Slot.GetComponentInParents<ImageImportDialog>() == null) return null;
            if (((Button)button).Pressed?.Target == null) return null;
            string target = ((Button)button).Pressed.Value.method;
            if (imageImportLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static Dictionary<string, string> videoImportLabelDict = new Dictionary<string, string>()
        {
            {"Return", "general.back"},
            {"Preset_Video", "videoImport.video"},
            {"Preset_360", "videoImport.360"},
            {"Preset_StereoVideo", "videoImport.stereo"},
            {"Preset_Stereo360", "videoImport.stereo360"},
            {"Preset_Depth", "videoImport.depth"},
            {"Preset_180", "videoImport.180"},
            {"Preset_Stereo180", "videoImport.stereo180"},
            {"AsRawFile", "general.rawFileImport"},
            {"Preset_HorizontalLR", "videoImport.stereo.horizontalLR"},
            {"Preset_HorizontalRL", "videoImport.stereo.horizontalRL"},
            {"Preset_VerticalLR", "videoImport.stereo.verticalLR"},
            {"Preset_VerticalRL", "videoImport.stereo.verticalRL"},
            {"Preset_DepthDefault", "videoImport.depth.default"},
            {"Preset_DepthPFCapture", "videoImport.depth.PFCapture"},
            {"Preset_DepthPFCaptureHorizontal", "videoImport.depth.PFCaptureHorizontal"},
            {"Preset_DepthHolofix", "videoImport.depth.holofix"}
        };
        private static string videoImportLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            if (button.Slot.GetComponentInParents<VideoImportDialog>() == null) return null;
            string target = null;
            if (((Button)button).Pressed?.Target != null) target = ((Button)button).Pressed.Value.method;
            if (button.Slot.GetComponent<ButtonRelay>() != null) target = button.Slot.GetComponent<ButtonRelay>().ButtonPressed?.Value.method;
            if (target == null) return null;
            if (videoImportLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static Dictionary<string, string> modelImportLabelDict = new Dictionary<string, string>()
        {
            // regular buttons
            {"Return", "general.back"},
            {"Preset_3DModel", "modelImport.model"},
            {"Preset_3DScan", "modelImport.3Dscan"},
            {"Preset_CADModel", "modelImport.CAD"},
            {"Preset_PointCloud", "modelImport.pointCloud"},
            {"Preset_VertexColorModel", "modelImport.vertexColoredModel"},
            {"OpenCustom", "modelImport.advancedSettings"},
            {"AsRawFile", "general.rawFileImport"},
            {"Preset_Regular3DModel", "modelImport.model.regular"},
            {"Preset_Separable3DModel", "modelImport.model.separable"},
            {"ScaleAuto", "modelImport.scale.auto"},
            {"ScaleHumanoid", "modelImport.scale.humanoid"},
            {"ScaleMeters", "modelImport.scale.meters"},
            {"ScaleMillimeters", "modelImport.scale.millimeters"},
            {"ScaleCentimeters", "modelImport.scale.centimeters"},
            {"ScaleInches", "modelImport.scale.inches"},
            {"OpenAdvancedSettings", "modelImport.advancedSettings"},
            {"RunImport", "modelImport.import"},
            // Buttons that use BooleanMemberEditor
            {"_autoScale", "modelImport.advanced.autoScale"},
            {"_preferSpecular", "modelImport.advanced.preferSpecular"},
            {"_calculateNormals", "modelImport.advanced.calculateNormals"},
            {"_calculateTangents", "modelImport.advanced.calculateTangents"},
            {"_importVertexColors", "modelImport.advanced.importVertexColors"},
            {"_importBones", "modelImport.advanced.importBones"},
            {"_importLights", "modelImport.advanced.importLights"},
            {"_calculateTextureAlpha", "modelImport.advanced.calculateTextureAlpha"},
            {"_importAlbedoColor", "modelImport.advanced.importAlbedoColor"},
            {"_importEmissive", "modelImport.advanced.importEmissive"},
            {"_colliders", "modelImport.advanced.generateColliders"},
            {"_animations", "modelImport.advanced.importAnimations"},
            {"_snappable", "modelImport.advanced.setupAsSnappable"},
            {"_timelapse", "modelImport.advanced.setupAsTimelapse"},
            {"_externalTextures", "modelImport.advanced.importExternalTextures"},
            {"_rig", "modelImport.advanced.importSkinnedMeshes"},
            {"_setupIK", "modelImport.advanced.setupIK"},
            {"_debugRig", "modelImport.advanced.visualizeRig"},
            {"_forceTpose", "modelImport.advanced.forceTPose"},
            {"_asPointCloud", "modelImport.advanced.asPointCloud"},
            {"_makeDualSided", "modelImport.advanced.makeDualSided"},
            {"_makeFlatShaded", "modelImport.advanced.makeFlatShaded"},
            {"_deduplicateInstances", "modelImport.advanced.deduplicateInstances"},
            {"_optimizeModel", "modelImport.advanced.optimize"},
            {"_splitSubmeshes", "modelImport.advanced.splitSubmeshes"},
            {"_generateRandomColors", "modelImport.advanced.generateRandomColors"},
            {"_spawnMaterialOrbs", "modelImport.advanced.spawnMaterialOrbs"},
            {"_importImagesByName", "modelImport.advanced.importImagesByName"},
            {"_forcePointFiltering", "modelImport.advanced.forcePointFiltering"},
            {"_forceNoMipMaps", "modelImport.advanced.noMipMaps"},
            {"_forceUncompressed", "modelImport.advanced.forceUncompressed"},
            {"_grabbable", "modelImport.advanced.makeGrabbable"},
            {"_scalable", "modelImport.advanced.makeScalable"},
            {"_importAtOrigin", "modelImport.advanced.positionAtOrigin"},
            {"_assetsOnObject", "modelImport.advanced.placeAssetsOnObject"},
            // Buttons that use EnumMemberEditor
            {"_textureConversion", "modelImport.advanced.imageFormat"},
            {"_material", "modelImport.advanced.material"},
            {"_importImageAlignment", "modelImport.advanced.alignAxis"},
            // Buttons that use PrimitiveMemberEditor
            {"_scale", "modelImport.advanced.scale"},
            {"_maxTextureSize", "modelImport.advanced.maxTextureSize"}
        };
        private static string modelImportLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            if (button.Slot.GetComponentInParents<ModelImportDialog>() == null) return null;
            string target = null;
            if (((Button)button).Pressed?.Target != null) target = ((Button)button).Pressed.Value.method;
            if (button.Slot.GetComponent<ButtonRelay>() != null) target = button.Slot.GetComponent<ButtonRelay>().ButtonPressed?.Value.method;
            if (button.Slot.GetComponentInParents<BooleanMemberEditor>() != null) target = ((RelayRef<IField>)typeof(BooleanMemberEditor).GetField("_target", AccessTools.all).GetValue(button.Slot.GetComponentInParents<BooleanMemberEditor>()))?.Target?.Name;
            if (button.Slot.GetComponentInParents<EnumMemberEditor>() != null) target = ((RelayRef<IField>)typeof(EnumMemberEditor).GetField("_target", AccessTools.all).GetValue(button.Slot.GetComponentInParents<EnumMemberEditor>()))?.Target?.Name;
            if (button.Slot.GetComponentInParents<PrimitiveMemberEditor>() != null) target = ((RelayRef<IField>)typeof(PrimitiveMemberEditor).GetField("_target", AccessTools.all).GetValue(button.Slot.GetComponentInParents<PrimitiveMemberEditor>()))?.Target?.Name;
            if (target == null) return null;
            if (modelImportLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static Dictionary<string, string> avatarCreatorLabelDict = new Dictionary<string, string>()
        {
            {"AlignHeadForward", "avatarCreator.alignHeadForward"},
            {"AlignHeadUp", "avatarCreator.alignHeadUp"},
            {"AlignHeadRight", "avatarCreator.alignHeadRight"},
            {"AlignHeadPosition", "avatarCreator.centerHeadPosition"},
            {"AlignHands", "avatarCreator.alignHands"},
            {"AlignToolAnchors", "avatarCreator.alignToolAnchors"},
            {"_useSymmetry", "avatarCreator.useSymmetry"},
            {"_showAnchors", "avatarCreator.showAnchors"},
            {"_setupVolumeMeter", "avatarCreator.setupVolumeMeter"},
            {"_setupEyes", "avatarCreator.setupEyes"},
            {"_setupFaceTracking", "avatarCreator.setupFaceTracking"},
            {"_setupProtection", "avatarCreator.protectAvatar"},
            {"OnCreate", "avatarCreator.create"}
        };
        private static string avatarCreatorLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            if (button.Slot.GetComponentInParents<AvatarCreator>() == null) return null;
            string target = null;
            if (button.Slot.GetComponent<Checkbox>() != null) target = button.Slot.GetComponent<Checkbox>().TargetState.Target.Name;
            if (((Button)button).Pressed?.Target != null) target = ((Button)button).Pressed.Value.method;
            if (button.Slot.GetComponent<ButtonRelay>() != null) target = button.Slot.GetComponent<ButtonRelay>().ButtonPressed?.Value.method;
            if (target == null) return null;
            if (avatarCreatorLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static Dictionary<string, string> settingsDialogLabelDict = new Dictionary<string, string>()
        {
            // Settings that use SettingSync components
            // left side
            {"Input.User.Height", "settings.myHeight"},
            {"Tutorials.GLOBAL.Hide", "settings.hideAllTutorials"},
            {"Input.ShowHints", "settings.showInteractionHints"},
            {"Input.Strafe", "settings.allowStrafing"},
            {"Input.UseHeadDirection", "settings.useHeadDirectionForMovement"},
            {"Input.SmoothTurn.Enabled", "settings.smoothTurn"},
            {"Input.SmoothTurn.ExclusiveMode", "settings.smoothTurnExclusiveMode"},
            {"Input.SmoothTurn.Speed", "settings.smoothTurnSpeed"},
            {"Input.SnapTurn.Angle", "settings.snapTurnAngle"},
            {"Input.MovementSpeed", "settings.noclipSpeed"},
            {"Input.MovementExponent", "settings.speedExponent"},
            {"Input.MoveThreshold", "settings.movementDeadzone"},
            {"Input.VibrationEnabled", "settings.controllerVibration"},
            {"Input.HapticsEnabled", "settings.hapticsFeedback"},
            {"Input.DisablePhysicalInteractions", "settings.disablePhysicalInteractions"},
            {"Input.Gestures", "settings.enableGestures"},
            {"Input.DoubleClickInterval", "settings.doubleClickInterval"},
            {"Input.DebugInputBinding", "settings.debugInputBindings"},
            {"Input.GripEquip", "settings.legacyDoubleGripEquip"},
            {"Userspace.WorldSwitcher.Enabled", "settings.legacyWorldSwitcher"},
            {"Cloud.Messaging.DoNotSendReadStatus", "settings.dontSendRealtimeMessageReadStatus"},
            {"Input.Laser.SmoothSpeed", "settings.laser.smoothSpeed"},
            {"Input.Laser.SmoothModulateStartAngle", "settings.laser.modulateStartAngle"},
            {"Input.Laser.SmoothModulateEndAngle", "settings.laser.modulateEndAngle"},
            {"Input.Laser.SmoothModulateExp", "settings.laser.modulateExponent"},
            {"Input.Laser.SmoothModulateMultiplier", "settings.laser.modulateSpeedMultiplier"},
            {"Input.Laser.StickThreshold", "settings.laser.stickThreshold"},
            {"Input.Laser.ShowInDesktop", "settings.laser.showInDesktop"},
            // right side
            {"Photos.AutoSavePath", "settings.autoSaveScreenshotPath"},
            {"Input.PoseSmoothing.Feet.Pos", "settings.FBT.feetPositionSmoothing"},
            {"Input.PoseSmoothing.Feet.Rot", "settings.FBT.feetRotationSmoothing"},
            {"Input.PoseSmoothing.Hips.Pos", "settings.FBT.hipsPositionSmoothing"},
            {"Input.PoseSmoothing.Hips.Rot", "settings.FBT.hipsRotationSmoothing"},
            {"Userspace.RadiantDash.Curvature", "settings.dash.curvature"},
            {"Userspace.RadiantDash.AnimationSpeed", "settings.dash.openCloseSpeed"},
            {"Settings.Graphics.DesktopFOV", "settings.desktopFOV"},
            // Settings that use LocalVariableSync components
            // left side
            {"SteamNetworkingSockets.Prefer", "settings.preferSteamNetworkingSockets"},
            {"NetworkManager.Disable", "settings.disableLAN"},
            {"WorldAnnouncer.FetchIncompatibleSessions", "settings.showIncompatibleSessions"},
            {"Session.MaxConcurrentTransmitJobs", "settings.maxConcurrentAssetTransfers"},
            // right side
            {"ViveHandTracking.Enabled", "settings.viveFingerTracking.enabled"},
            {"ViveHandTracking.HandSnapDistance", "settings.viveFingerTracking.snapDistance"},
            {"ViveHandTracking.UseFingersWhenSnapped", "settings.viveFingerTracking.useWhenSnapped"},
            {"Windows.KeepOriginalScreenshotFormat", "settings.keepOriginalScreenshotFormat"}
        };
        private static string settingsDialogLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            if (button.Slot.GetComponentInParents<SettingsDialog>() == null) return null;
            string target = null;
            if (button.Slot.GetComponent<SettingSync>() != null) target = button.Slot.GetComponent<SettingSync>().SettingPath.Value;
            else if (button.Slot.GetComponentInChildren<SettingSync>() != null) target = button.Slot.GetComponentInChildren<SettingSync>().SettingPath.Value; // text input fields have the SettingSync a slot lower
            else if (button.Slot.GetComponent<LocalVariableSync<bool>>() != null) target = button.Slot.GetComponent<LocalVariableSync<bool>>().Variable.Value;
            else if (button.Slot.GetComponent<LocalVariableSync<int>>() != null) target = button.Slot.GetComponent<LocalVariableSync<int>>().Variable.Value;
            else if (button.Slot.GetComponent<LocalVariableSync<float>>() != null) target = button.Slot.GetComponent<LocalVariableSync<float>>().Variable.Value;
            if (target == null) return null;
            if (settingsDialogLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static Dictionary<string, string> dashExitLabelDict = new Dictionary<string, string>()
        {
            {"OnExitAndSave", "exit.saveHomes"},
            {"OnExitAndDiscard", "exit.discardHomes"}
        };
        private static string dashExitLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<ExitScreen>() == null) return null;
            string target = null;
            if (button.Slot.GetComponent<ButtonRelay>() != null) target = button.Slot.GetComponent<ButtonRelay>().ButtonPressed?.Value.method;
            if (target == null) return null;
            if (dashExitLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static Dictionary<SessionControlDialog.Tab, string> sessionControlTabLabelDict = new Dictionary<SessionControlDialog.Tab, string>()
        {
            {SessionControlDialog.Tab.Settings, "sessionControl.tab.settings"},
            {SessionControlDialog.Tab.Users, "sessionControl.tab.users"},
            {SessionControlDialog.Tab.Permissions, "sessionControl.tab.permissions"}
        };
        private static Dictionary<string, string> sessionControlLabelDict = new Dictionary<string, string>()
        {
            // Button Pressed actions
            {"GetSessionOrb", "sessionControl.settings.getSessionOrb"},
            {"GetWorldOrb", "sessionControl.settings.getWorldOrb"},
            {"CopySessionURL", "sessionControl.settings.copySessionURL"},
            {"CopyWorldURL", "sessionControl.settings.copyWorldURL"},
            {"CopyRecordURL", "sessionControl.settings.copyRecordURL"},
            {"OnSave", "sessionControl.settings.saveChanges"},
            {"OnSaveAs", "sessionControl.settings.saveAs"},
            {"OnSaveCopy", "sessionControl.settings.saveCopy"},
            {"OnMute", "sessionControl.users.mute"},
            {"OnJump", "sessionControl.users.jump"},
            {"OnRespawn", "sessionControl.users.respawn"},
            {"OnSilence", "sessionControl.users.silence"},
            {"OnKick", "sessionControl.users.kick"},
            {"OnBan", "sessionControl.users.ban"},
            {"OnClearUserPermissionOverrides", "sessionControl.permissions.clearUserOverrides"},
            // Buttons using WorldValueSync
            {"WorldName", "sessionControl.settings.worldName"},
            {"MaxUsers", "sessionControl.settings.maxUsers"},
            {"MobileFriendly", "sessionControl.settings.mobileFriendly"},
            {"WorldDescription", "sessionControl.settings.worldDescription"},
            {"editMode", "sessionControl.settings.editMode"},
            {"AwayKickEnabled", "sessionControl.settings.autoKickAFKUsers"},
            {"AwayKickMinutes", "sessionControl.settings.maxAFKMinutes"},
            {"HideFromListing", "sessionControl.settings.dontShowInSessionLists"},
            {"AutoSaveEnabled", "sessionControl.settings.autosave"},
            {"AutoSaveInterval", "sessionControl.settings.autosaveInterval"},
            {"AutoCleanupEnabled", "sessionControl.settings.cleanupUnusedAssets"},
            {"AutoCleanupInterval", "sessionControl.settings.cleanupInterval"},
        };
        private static Dictionary<string, string> sessionDefaultPermissionsMap = new Dictionary<string, string>()
        {
            {"Session.Permission.Anonymous", "sessionControl.permissions.setRoleForAnonymous"},
            {"Session.Permission.Vistor", "sessionControl.permissions.setRoleForVisitor"},
            {"Session.Permission.Contact", "sessionControl.permissions.setRoleForContact"},
            {"Session.Permission.Host", "sessionControl.permissions.setRoleForHost"}
        };
        private static Dictionary<CloudX.Shared.SessionAccessLevel, string> sessionControlAccessLevelLabelDict = new Dictionary<CloudX.Shared.SessionAccessLevel, string>()
        {
            {CloudX.Shared.SessionAccessLevel.Private, "sessionControl.settings.access.private"},
            {CloudX.Shared.SessionAccessLevel.LAN, "sessionControl.settings.access.LAN"},
            {CloudX.Shared.SessionAccessLevel.Friends, "sessionControl.settings.access.contacts"},
            {CloudX.Shared.SessionAccessLevel.FriendsOfFriends, "sessionControl.settings.access.contactsPlus"},
            {CloudX.Shared.SessionAccessLevel.RegisteredUsers, "sessionControl.settings.access.registered"},
            {CloudX.Shared.SessionAccessLevel.Anyone, "sessionControl.settings.access.anyone"},
        };
        private static string sessionControlLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<SessionControlDialog>() == null) return null;
            // top row of buttons
            if (button.Slot.GetComponent<ButtonRelay<SessionControlDialog.Tab>>() != null)
            {
                return localeStrings[sessionControlTabLabelDict[button.Slot.GetComponent<ButtonRelay<SessionControlDialog.Tab>>().Argument.Value]];
            }
            string target = null;
            if (((Button)button).Pressed?.Target != null) target = ((Button)button).Pressed.Value.method;
            else if (button.Slot.GetComponent<ButtonRelay<int>>() != null)
            {
                target = button.Slot.GetComponent<ButtonRelay<int>>().ButtonPressed?.Value.method;
                if (target == "SetRole")
                {
                    string targetPermission = button.Slot.GetComponentInChildren<Text>()?.Content.Value;
                    string targetUser = button.Slot.Parent.Parent.Parent.Children.ElementAt(0).GetComponentInChildren<Text>()?.Content.Value;
                    string targetDefault = button.Slot.Parent.Parent.Parent.Children.ElementAt(0).GetComponentInChildren<LocaleStringDriver>()?.Key.Value;
                    if (targetDefault != null) return localeStrings[sessionDefaultPermissionsMap[targetDefault]].Replace("{{PERMISSION}}", targetPermission);
                    return localeStrings["sessionControl.permissions.setRoleForUser"].Replace("{{USERNAME}}", targetUser).Replace("{{PERMISSION}}", targetPermission);
                }
            }
            else if (button.Slot.GetComponent<ValueRadio<CloudX.Shared.SessionAccessLevel>>() != null) return localeStrings[sessionControlAccessLevelLabelDict[button.Slot.GetComponent<ValueRadio<CloudX.Shared.SessionAccessLevel>>().OptionValue.Value]];

            // check all the types of WorldValueSync
            WorldValueSync<string> valueSyncString = button.Slot.GetComponentInChildren<WorldValueSync<string>>();
            if (valueSyncString != null) target = ((IField)typeof(WorldValueSync<string>).GetField("_targetWorldValue", AccessTools.all).GetValue(valueSyncString)).Name;
            WorldValueSync<int> valueSyncInt = button.Slot.GetComponent<WorldValueSync<int>>();
            if (valueSyncInt != null) target = ((IField)typeof(WorldValueSync<int>).GetField("_targetWorldValue", AccessTools.all).GetValue(valueSyncInt)).Name;
            WorldValueSync<bool> valueSyncBool = button.Slot.GetComponent<WorldValueSync<bool>>();
            if (valueSyncBool != null) target = ((IField)typeof(WorldValueSync<bool>).GetField("_targetWorldValue", AccessTools.all).GetValue(valueSyncBool)).Name;
            WorldValueSync<float> valueSyncFloat = button.Slot.GetComponent<WorldValueSync<float>>();
            if (valueSyncFloat != null) target = ((IField)typeof(WorldValueSync<float>).GetField("_targetWorldValue", AccessTools.all).GetValue(valueSyncFloat)).Name;

            if (target == null) return null;
            if (sessionControlLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static Dictionary<string, string> contactsDialogLabelDict = new Dictionary<string, string>()
        {
            {"SearchTextChanged", "contacts.searchBar"},
            {"OnJoin", "general.joinSession"},
            {"OnInviteFriend", "contacts.inviteHere"},
            {"OnSendCredits", "contacts.sendCredits"},
            {"OnGiftStorage", "contacts.giftStorage"},
            {"OnRemoveFriend", "contacts.removeContact"},
            {"OnBanFromAll", "contacts.banFromHosted"},
            {"OnBanFromCurrent", "contacts.banFromCurrent"},
            {"OnAddFriend", "contacts.addContact"},
            {"OnIgnoreRequest", "contacts.ignoreRequest"},
            {"MessageSubmitPressed", "contacts.sendMessage"},
            {"OnStartRecordingVoiceMessage", "contacts.recordVoiceMessage"}
        };
        private static string contactsDialogLabels(IButton button, ButtonEventData eventData)
        {
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            if (button.Slot.GetComponentInParents<FriendsDialog>() == null) return null;
            string target = null;
            target = button.Pressed?.Value.method;
            TextEditor textEditor = button.Slot.GetComponent<TextEditor>();
            if (textEditor != null) {
                target = textEditor.EditingChanged?.Value.method ?? textEditor.SubmitPressed?.Value.method;
            }
            else if (button.Slot.GetComponent<ButtonRelay>() != null && button.Slot.GetComponent<ButtonRelay>().ButtonPressed?.Value.method == "OnSendMessage")
            {
                return localeStrings["contacts.sendItem"];
            }
            else if (button.Slot.GetComponent<ButtonRelay<System.Uri>>() != null && button.Slot.GetComponent<ButtonRelay<System.Uri>>().ButtonPressed?.Value.method == "SpawnMessageItem")
            {
                return localeStrings["contacts.spawnItem"];
            }

            if (target != null && contactsDialogLabelDict.TryGetValue(target, out target)) return localeStrings[target];

            // check for sugar cubes message
            if (((Button)button).ColorDrivers.Count == 1 && ((Button)button).ColorDrivers.ElementAt<InteractionElement.ColorDriver>(0).NormalColor.Value.ToHexString(true) == "#FFFFBFCC")
            {
                return localeStrings["contacts.spawnSugarCubes"];
            }

            return null;
        }


        private static Dictionary<string, string> audioStreamLabelDict = new Dictionary<string, string>()
        {
            {"OnToggleBroadcast", "audioStream.panel.spatialized"},
            {"OnTogglePlayForOwner", "audioStream.panel.playForOwner"}
        };
        private static string audioStreamLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<AudioStreamController>() == null) return null;
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;

            string target = button.Pressed?.Value.method;
            if (target != null && audioStreamLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static Dictionary<string, string> coreWorldsLabelDict = new Dictionary<string, string>()
        {
            {"OnContentHub", "coreWorlds.contentHub"},
            {"OnMetaverseTrainingCenter", "coreWorlds.MTC"},
            {"OnCloudHome", "coreWorlds.cloudHome"}
        };
        private static string coreWorldsLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<CommonWorldsFacetPreset>() == null) return null;
            string target = button.Slot.GetComponent<ButtonRelay>().ButtonPressed.Value.method;
            if (coreWorldsLabelDict.TryGetValue(target, out target)) return localeStrings[target];
            return null;
        }


        private static string profileFacetLabels(IButton button, ButtonEventData eventData)
        {
            SimpleProfileFacetPreset profileFacet = button.Slot.GetComponentInParents<SimpleProfileFacetPreset>();
            if (profileFacet == null) return null;
            if (button.Slot.GetComponent<ButtonRelay>().ButtonPressed.Value.method == "OnProfileImageSet") return localeStrings["profileFacet.setImage"];
            if (button.Pressed.Value.method == "OnLoginLogout")
            {
                return localeStrings[profileFacet.Cloud.CurrentUser == null? "profileFacet.login" : "profileFacet.logout"];
            }
            return null;
        }


        private static string toolsFacetLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponent<AvatarCreatorSpawner>() != null) return localeStrings["toolsFacet.spawnAvatarCreator"];
            if (button.Slot.GetComponent<FullBodyCalibratorSpawner>() != null) return localeStrings["toolsFacet.spawnFullBodyCalibrator"];
            if (button.Slot.GetComponent<InteractiveCameraSpawner>() != null) return localeStrings["toolsFacet.spawnCamera"];
            if (button.Slot.GetComponent<GenericModalDialogSpawner<NewWorldDialog>>() != null) return localeStrings["toolsFacet.createNewWorld"];
            if (button.Slot.GetComponent<AudioStreamSpawner>() != null) return localeStrings["toolsFacet.streamAudio"];
            if (button.Slot.GetComponent<GenericUserspaceDialogSpawner<DepositAddressDialog>>() != null) return localeStrings["toolsFacet.depositNCR"];
            if (button.Slot.GetComponent<GenericUserspaceDialogSpawner<SendCreditsDialog>>() != null) return localeStrings["toolsFacet.withdrawNCR"];
            if (button.Slot.GetComponent<GenericModalDialogSpawner<TOTP_Dialog>>() != null) return localeStrings["toolsFacet.setup2FA"];
            if (button.Slot.GetComponent<GenericUserspaceDialogSpawner<EngineDebugDialog>>() != null) return localeStrings["toolsFacet.debug"];
            if (button.Slot.GetComponent<GenericModalDialogSpawner<StoragePurchaseDialog>>() != null) return localeStrings["toolsFacet.buyStorage"];
            return null;
        }


        private static Dictionary<string, string> debugPanelLabelDict = new Dictionary<string, string>()
        {
            {"SwitchToGatherJobs", "debugPanel.tabs.gatherJobs"},
            {"SwitchToWorlds", "debugPanel.worlds"},
            {"SwitchToFocusedWorld", "debugPanel.focusedWorld"},
            {"SwitchToPhysics", "debugPanel.physics"},
            {"SwitchToBackgroundJobs", "debugPanel.backgroundJobs"},
            {"SwitchToLoadedAssets", "debugPanel.assets"},
            {"SwitchToSpecial", "debugPanel.special"},
            {"SwitchToWebHosts", "debugPanel.webHosts"},
            {"SwitchToBans", "debugPanel.bans"},
            {"UploadCC0Textures", "debugPanel.special.uploadCC0Textures"},
            {"UploadStandardAssets", "debugPanel.special.uploadStandardAssets"},
            {"SwitchToNormalDash", "debugPanel.special.switchToNormalDash"},
            {"CopyBackgroundWorkerSnapshot", "debugPanel.special.copyBackgroundThreadProcessingSnapshotToClipboard"},
            {"StartRecordingPerfMetrics", "debugPanel.special.startRecordingPerformanceMetrics"},
            {"SaveObjectPoolStats", "debugPanel.special.saveObjectPoolStats"},
            {"ForceFullGC", "debugPanel.special.forceFullGarbageCollection"},
            {"OnRemoveHostPermission", "debugPanel.webHosts.removeSetting"},
            {"OnRemoveBan", "debugPanel.bans.removeBan"}
        };
        private static string debugPanelLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<EngineDebugDialog>() == null) return null;
            // only care for buttons on the UIX Canvas for now:
            if (button.GetType() != typeof(Button)) return null;
            string target = button.Slot.GetComponent<ButtonRelay<string>>()?.ButtonPressed?.Value.method ?? button.Pressed?.Value.method;

            if (target != null) return localeStrings[debugPanelLabelDict[target]];
            return null;
        }


        private static Dictionary<WorldCloseAction.CloseAction, string> worldCloseButtonLabelDict = new Dictionary<WorldCloseAction.CloseAction, string>()
        {
            {WorldCloseAction.CloseAction.LeaveOrOpenCloseScreen, "closeWorld.leave"},
            {WorldCloseAction.CloseAction.Save, "closeWorld.saveChanges"},
            {WorldCloseAction.CloseAction.SaveAs, "closeWorld.saveAs"},
            {WorldCloseAction.CloseAction.Discard, "closeWorld.discardChanges"}
        };
        private static string worldCloseButtonLabels(IButton button, ButtonEventData eventData)
        {
            WorldCloseAction.CloseAction? closeAction = button.Slot.GetComponent<WorldCloseAction>()?.Action.Value;
            if (closeAction != null) return localeStrings[worldCloseButtonLabelDict[(WorldCloseAction.CloseAction)closeAction]];
            return null;
        }


        private static string assortedFacetLabels(IButton button, ButtonEventData eventData)
        {
            if (button.Slot.GetComponentInParents<FreeformDashFacetPreset>() != null) return localeStrings["toggleFreeformDash"];
            if (button.Slot.GetComponentInParents<ClipboardPasteFacetPreset>() != null) return localeStrings["pasteFromClipboard"];
            if (button.Slot.GetComponentInParents<SeatedModeFacetPreset>() != null) return localeStrings["toggleSeatedMode"];
            return null;
        }


        private static Dictionary<NameplateVisibility, string> nameplateVisibilityLabelDict = new Dictionary<NameplateVisibility, string>()
        {
            {NameplateVisibility.All, "nameplateVisibility.all"},
            {NameplateVisibility.NonContacts, "nameplateVisibility.nonContacts"},
            {NameplateVisibility.None, "nameplateVisibility.none"}
        };
        private static string nameplateVisibilityLabels(IButton button, ButtonEventData eventData)
        {
            ButtonValueCycle<NameplateVisibility> valueCycle = button.Slot.GetComponentInParents<ButtonValueCycle<NameplateVisibility>>();
            if (valueCycle != null) return localeStrings[nameplateVisibilityLabelDict[valueCycle.TargetValue.Target.Value]];
            return null;
        }
    }
}
