1. 'GBT-2659.json'<br/>
    经过 struct 生成的 'GBT-2659-2000' 数据，以 JSON 格式存储。<br/>
2. 'ISO-3166_S.json'<br/>
    去掉了不常用列，经过 struct 生成的 'ISO-3166' 数据的简化版，以 JSON 格式存储。<br/>
3. 'ISO-3166_S-NN.json'<br/>
    合并了 GBT-2659 和 ISO-3166_S 的数据，以 JSON 格式存储。<br/>
4. 'ISO-3166_S-NN.js'<br/>
    合并了 GBT-2659 和 ISO-3166_S 的数据，以 JavaScript 的 Array 形式存储。<br/>

适用于 .NET 的 Struct 定义：
```
struct ISO3166_NN{
    public string Name;
    public string Name_ZH_S;
    public string Name_EN_S;
    public string Name_ZH_F;    // 有问题
    public string Name_EN_F;    // 有问题

    public int Code;
    public string Region;
    public string SubRegion;
    public string IntermediateRegion;
    public int? RegionCode;
    public int? SubRegionCode;
    public int? IntermediateRegionCode;

    public ISO3166_NN(string name, string name_ZH_S, string name_EN_S, string name_ZH_F, string name_EN_F, int code, string region, string subRegion, string intermediateRegion, int? regionCode, int? subRegionCode, int? intermediateRegionCode)
    {
        Name = name;
        Name_ZH_S = name_ZH_S;
        Name_EN_S = name_EN_S;
        Name_ZH_F = name_ZH_F;
        Name_EN_F = name_EN_F;
        Code = code;
        Region = region;
        SubRegion = subRegion;
        IntermediateRegion = intermediateRegion;
        RegionCode = regionCode;
        SubRegionCode = subRegionCode;
        IntermediateRegionCode = intermediateRegionCode;
    }
}
```