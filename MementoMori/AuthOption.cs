﻿using MementoMori.Ortega.Share.Data.Item;
using MementoMori.Ortega.Share.Enums;

namespace MementoMori;

public class AuthOption
{
    [Obsolete]
    public string ClientKey { get; set; }

    public string AuthUrl { get; set; }
    public string DeviceToken { get; set; }
    public string AppVersion { get; set; }
    public string OSVersion { get; set; }
    public string ModelName { get; set; }

    [Obsolete]
    public long UserId { get; set; }

    public long LastLoginUserId { get; set; }

    public List<AccountInfo> Accounts { get; set; } = new();
}

public class AccountInfo
{
    public string Name { get; set; }
    public long UserId { get; set; }
    public string ClientKey { get; set; }
    public bool AutoLogin { get; set; }
}

public class GameConfig
{
    public class ShopDiscountItem : IUserItem
    {
        public long ItemCount { get; }
        public long ItemId { get; set; }
        public ItemType ItemType { get; set; }
        public int MinDiscountPercent { get; set; }
    }

    public class ShopAutoBuyItem
    {
        public UserItem BuyItem { get; set; }
        public long ShopTabId { get; set; }
        public int MinDiscountPercent { get; set; }
        public UserItem ConsumeItem { get; set; }
    }

    public class DungeonBattleRelicSortInfo
    {
        public long Id { get; set; }
        public string Desc { get; set; }
    }

    public class GachaConfigModel
    {
        public List<UserItem> AutoGachaConsumeUserItems { get; set; } = new();
    }

    public class ShopConfig
    {
        public List<ShopAutoBuyItem> AutoBuyItems { get; set; } = new();

        public ShopConfig()
        {
        }
    }

    public class AutoJobModel
    {
        public bool DisableAll { get; set; }
        public bool AutoReinforcementEquipmentOneTime { get; set; }
        public bool AutoPvp { get; set; }
        public bool AutoLegendLeague { get; set; }
        public bool AutoDungeonBattle { get; set; }
        public bool AutoUseItems { get; set; }
        public bool AutoFreeGacha { get; set; }
        public bool AutoRankUpCharacter { get; set; }
        public bool AutoOpenGuildRaid { get; set; }
        public bool AutoLocalRaid { get; set; }
        public bool AutoDeployGuildDefense { get; set; }

        public string DailyJobCron { get; set; } = "0 10 4 ? * *";
        public string HourlyJobCron { get; set; } = "0 30 0,4,8,12,16,20 ? * *";
        public string PvpJobCron { get; set; } = "0 0 20 ? * *";
        public string LegendLeagueJobCron { get; set; } = "0 10 20 ? * *";
        public string GuildRaidBossReleaseCron { get; set; } = "0 0 * ? * *";
        public string AutoBuyShopItemJobCron { get; set; } = "0 9 9,12,15,18 ? * *";
        public string AutoLocalRaidJobCron { get; set; } = "0 31 12,19 ? * *";
        public string AutoDeployGuildDefenseJobCron { get; set; } = "0 20 19 ? * *";
    }

    public class BountyQuestAutoModel
    {
        public List<UserItem> TargetItems { get; set; } = new();
        public int AllowedNonTargetItemCount { get; set; } = 100;
        public int AutoRefreshCount { get; set; }
    }

    public class WeightedItem : IUserItem
    {
        public WeightedItem(ItemType itemType, long itemId, double weight)
        {
            ItemId = itemId;
            ItemType = itemType;
            Weight = weight;
        }

        public long ItemCount { get; set; }
        public long ItemId { get; set; }
        public ItemType ItemType { get; set; }
        public double Weight { get; set; }
    }

    public class LocalRaidConfig
    {
        public List<WeightedItem> RewardItems { get; set; } = new();
        // {
        //     new WeightedItem(ItemType.ExchangePlaceItem, 4, 4), // 符石兑换券
        //     new WeightedItem(ItemType.CharacterTrainingMaterial, 2, 3), // 潜能宝珠
        //     new WeightedItem(ItemType.EquipmentReinforcementItem, 2, 2.5), // 强化秘药
        //     new WeightedItem(ItemType.CharacterTrainingMaterial, 1, 2), // 经验珠
        //     new WeightedItem(ItemType.EquipmentReinforcementItem, 1, 1), // 强化水
        // };
        
        public bool SelfCreateRoom { get; set; }
    }

    public class DungeonBattleConfig
    {
        public List<ShopDiscountItem> ShopTargetItems { get; set; } = new();

        [Obsolete("Use ShopDiscountItem.MinDiscountPercent")]
        public int ShopDiscountPercent { get; set; } = 0;

        public bool PreferTreasureChest { get; set; }
        public int MaxUseRecoveryItem { get; set; }
    }

    [Obsolete]
    public class LoginConfig
    {
        [Obsolete]
        public bool AutoLogin { get; set; }
    }

    public class ItemsConfig
    {
        public List<AutoUseItemType> AutoUseItemTypes { get; set; } = new();
    }

    public enum AutoUseItemType
    {
        Others,

        /// <summary>
        /// 一袋钻石
        /// </summary>
        DiamondBag,

        /// <summary>
        /// 未鉴定符石
        /// </summary>
        MysteryRune,

        /// <summary>
        /// 魔女的来信 R
        /// </summary>
        WitchLetterR,

        /// <summary>
        /// 魔女的来信 SR
        /// </summary>
        WitchLetterSr,

        /// <summary>
        /// 魔女的心片
        /// </summary>
        WitchShard,

        /// <summary>
        /// 小壶
        /// </summary>
        Pot,

        /// <summary>
        /// 大壶
        /// </summary>
        Amphora,

        /// <summary>
        /// 封印宝箱
        /// </summary>
        SealedChest,

        /// <summary>
        /// 魔女的来信礼盒
        /// </summary>
        WitchLetterGift,

        /// <summary>
        /// 命运盒
        /// </summary>
        ChestOfChance
    }


    public AutoJobModel AutoJob { get; set; } = new();
    public GachaConfigModel GachaConfig { get; set; } = new();
    public DungeonBattleRelicSortInfo[] DungeonBattleRelicSort { get; set; }
    public int AutoRequestDelay { get; set; }
    public bool RecordBattleLog { get; set; } = true;
    public string BattleLogDir { get; set; } = "BattleLogs/";
    public BountyQuestAutoModel BountyQuestAuto { get; set; } = new();
    public DungeonBattleConfig DungeonBattle { get; set; } = new();
    public ShopConfig Shop { get; set; } = new();
    [Obsolete("Use config in PlayerOption")]
    public LocalRaidConfig LocalRaid { get; set; } = new();
    public LoginConfig Login { get; set; } = new();
    public ItemsConfig Items { get; set; } = new();
}

public class PlayersOption : Dictionary<long, PlayerOption>
{
}

public class PlayerOption
{
    public long PlayerId { get; set; }
    public PvpOption BattleLeague { get; set; } = new();
    public PvpOption LegendLeague { get; set; } = new();
    public GameConfig.LocalRaidConfig LocalRaid { get; set; } = new();
}

public class PvpOption
{
    public TargetSelectStrategy SelectStrategy { get; set; } = TargetSelectStrategy.Random;
    public List<CharacterFilter> CharacterFilters { get; set; } = new();
    public List<long> ExcludePlayerIds { get; set; } = new();
}

public enum TargetSelectStrategy
{
    Random,
    LowestBattlePower,
    HighestBattlePower
}

public class CharacterFilter
{
    public long CharacterId { get; set; }
    public CharacterFilterStrategy FilterStrategy { get; set; } = CharacterFilterStrategy.Character;
    public BattleParameterType BattleParameterType { get; set; } = BattleParameterType.AttackPower;
}

public enum CharacterFilterStrategy
{
    /// <summary>
    /// 不包含这个角色
    /// </summary>
    Character,

    /// <summary>
    /// 这个角色的属性比自己的角色的高
    /// </summary>
    PropertyMoreThanSelf
}