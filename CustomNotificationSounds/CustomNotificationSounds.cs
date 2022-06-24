using FrooxEngine;
using HarmonyLib;
using NeosModLoader;

public class CustomNotificationSounds : NeosMod
{
	public override string Author => "Kodu";
	public override string Link => "https://github.com/Kodufan/CustomNotificationSounds";
	public override string Name => "CustomNotificationSounds";
	public override string Version => "1.0.0";


	public static ModConfiguration config;

	[AutoRegisterConfigKey]
	private static ModConfigurationKey<string> RecieveMessage = new ModConfigurationKey<string>("Message sound", "Message sound", () => "neosdb:///52c29a4461c1cf87dccd1cb84baeb57f5f0b4ddc99826c4f07c42cf9378104f9.wav");
	
	[AutoRegisterConfigKey]
	private static ModConfigurationKey<string> RecieveInvite = new ModConfigurationKey<string>("Invite sound", "Invite sound", () => "neosdb:///985813d146a8d19bb4b765fb1e91d93b95990b8626b604a4940fd140038aafd2.wav");

	[AutoRegisterConfigKey]
	private static ModConfigurationKey<string> SendCredits = new ModConfigurationKey<string>("Send credits sound", "Send credits sound", () => "neosdb:///84717a2baaf81e7099e67e3dc18fc1b2d2f4d6fe40d4763d310430569dff0597.wav");

	[AutoRegisterConfigKey]
	private static ModConfigurationKey<string> SendCredits2 = new ModConfigurationKey<string>("Second send credits sound", "Second send credits sound", () => "neosdb:///84717a2baaf81e7099e67e3dc18fc1b2d2f4d6fe40d4763d310430569dff0597.wav");

	[AutoRegisterConfigKey]
	private static ModConfigurationKey<string> RecieveCredits = new ModConfigurationKey<string>("Recieve credits sound", "Recieve credits sound", () => "neosdb:///90293ec59b2f19206c5b8070e2537c45cca4244fa5f9b292397178bf09e6521d.wav");

	[AutoRegisterConfigKey]
	private static ModConfigurationKey<string> RecieveCredits2 = new ModConfigurationKey<string>("Second recieve credits sound", "Second recieve credits sound", () => "neosdb:///00e148c60bd6f7b4de72f411844ab7daa36bbc825374db14f78b723e1576b989.wav");

	[AutoRegisterConfigKey]
	private static ModConfigurationKey<string> VoiceMuted = new ModConfigurationKey<string>("Voice muted sound", "Voice muted sound", () => "neosdb:///4e1f33451479b9bf708c4231418d5bdf3125a233b7b2bd4cabce680a36e04b4f.wav");

	[AutoRegisterConfigKey]
	private static ModConfigurationKey<string> VoiceUnmuted = new ModConfigurationKey<string>("Voice unmuted sound", "Voice unmuted sound", () => "neosdb:///93d1210fdfc21e0307f9b1ef075d64711b2488ed4779d93ee3359234c7f1c809.wav");

	public override void OnEngineInit()
	{
		config = GetConfiguration();
		config.Save(true);

		Harmony harmony = new Harmony($"dev.{Author}.{Name}");
		harmony.PatchAll();


	}

	[HarmonyPatch(typeof(NeosAssets.Sounds.RadiantUI), "get_User_Recieve_Message_02_1")]
	class MessageNotificationSoundPatch
	{
		[HarmonyPostfix]
		static void Postfix(ref System.Uri __result)
		{
			__result = new System.Uri(config.GetValue(RecieveMessage));
		}
	}

	[HarmonyPatch(typeof(NeosAssets.Sounds.RadiantUI), "get_User_Recieve_Invite_01")]
	class InviteNotificationSoundPatch
	{
		[HarmonyPostfix]
		static void Postfix(ref System.Uri __result)
		{
			__result = new System.Uri(config.GetValue(RecieveInvite));
		}
	}

	[HarmonyPatch(typeof(NeosAssets.Sounds.RadiantUI), "get_User_Send_Credits_01")]
	class SendCreditsNotificationSoundPatch
	{
		[HarmonyPostfix]
		static void Postfix(ref System.Uri __result)
		{
			__result = new System.Uri(config.GetValue(SendCredits));
		}
	}

	[HarmonyPatch(typeof(NeosAssets.Sounds.RadiantUI), "get_User_Send_Credits_02")]
	class SendCredits2NotificationSoundPatch
	{
		[HarmonyPostfix]
		static void Postfix(ref System.Uri __result)
		{
			__result = new System.Uri(config.GetValue(SendCredits2));
		}
	}

	[HarmonyPatch(typeof(NeosAssets.Sounds.RadiantUI), "get_User_Recieve_Credits_01")]
	class RecieveCreditsNotificationSoundPatch
	{
		[HarmonyPostfix]
		static void Postfix(ref System.Uri __result)
		{
			__result = new System.Uri(config.GetValue(RecieveCredits));
		}
	}

	[HarmonyPatch(typeof(NeosAssets.Sounds.RadiantUI), "get_User_Recieve_Credits_02")]
	class RecieveCredits2NotificationSoundPatch
	{
		[HarmonyPostfix]
		static void Postfix(ref System.Uri __result)
		{
			__result = new System.Uri(config.GetValue(RecieveCredits2));
		}
	}

	[HarmonyPatch(typeof(NeosAssets.Sounds.RadiantUI), "get_User_Voice_Muted_01")]
	class VoiceMutedNotificationSoundPatch
	{
		[HarmonyPostfix]
		static void Postfix(ref System.Uri __result)
		{
			__result = new System.Uri(config.GetValue(VoiceMuted));
		}
	}

	[HarmonyPatch(typeof(NeosAssets.Sounds.RadiantUI), "get_User_Voice_Unmuted_01")]
	class VoiceUnmutedNotificationSoundPatch
	{
		[HarmonyPostfix]
		static void Postfix(ref System.Uri __result)
		{
			__result = new System.Uri(config.GetValue(VoiceUnmuted));
		}
	}
}