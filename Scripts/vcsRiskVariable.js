﻿var projectManagementParameter = 
       [["a", "Species planted (where applicable) associated with more than 25% of the stocks on which GHG credits have previously been issued are not native or proven to be adapted to the same or similar agro-ecological zone(s) in which the project is located.", "2"],
        ["b", "Ongoing enforcement to prevent encroachment by outside actors is required to protect more than 50% of stocks on which GHG credits have previously been issued.", "2"],
        ["c", "Management team does not include individuals with significant experience in all skills necessary to successfully undertake all project activities (ie, any area of required experience is not covered by at least one individual with at least 5 years experience in the area).", "2"],
        ["d", "Management team does not maintain a presence in the country or is located more than a day of travel from the project site, considering all parcels or polygons in the project area.", "2"],
        ["e", "Mitigation: Management team includes individuals with significant experience in AFOLU project design and implementation, carbon accounting and reporting (eg, individuals who have successfully managed projects through validation, verification and issuance of GHG credits) under the VCS Program or other approved GHG programs.", "-2"], ["f", "Mitigation: Adaptive management plan in place.",  "-2"]];

// Total Project Management (PM) [as applicable, (a + b + c + d + e + f)] 
// Total may be less than zero


var financialViabilityParameter =
    [
        ["a", "a. Project cash flow breakeven point is greater than 10 years from the current risk assessment", 3],
        ["b", "b. Project cash flow breakeven point is greater than 7 and up to 10 years from the current risk assessment",2],
        ["c", "c. Project cash flow breakeven point greater than 4 and up to 7 years from the current risk assessment",1],
        ["d", "d. Project cash flow breakeven point is 4 years or less from the current risk assessment",0],
        ["e", "e. Project has secured less than 15% of funding needed to cover the total cash out before the project reaches breakeven",3],
        ["f", "f. Project has secured 15% to less than 40% of funding needed to cover the total cash out required before the project reaches breakeven",2],
        ["g", "g. Project has secured 40% to less than 80% of funding needed to cover the total cash out required before the project reaches breakeven",1],
        ["h", "h. Project has secured 80% or more of funding needed to cover the total cash out before the project reaches breakeven",0],
        ["i", "i. Mitigation: Project has available as callable financial resources at least 50% of total cash out before project reaches breakeven",-2]
        //Total Financial Viability (FV) [as applicable, ((a, b, c or d) + (e, f, g or h) + i)] 
        //Total may not be less than zero. 
    [
        
        ["a" , "a. NPV from the most profitable alternative land use activity is expected to be at least 100% more than that associated with project activities; or where baseline activities are subsistence-driven, net positive community impacts are not demonstrated", 8], 
        ["b" , "b. NPV from the most profitable alternative land use activity is expected to be between 50% and up to100% more than from project activities",  6],
        ["c" , "c. NPV from the most profitable alternative land use activity is expected to be between 20% and up to 50% more than from project activities",  4],
        ["d" , "d. NPV from the most profitable alternative land use activity is expected to be between 20% more than and up to 20% less than from project activities; or where baseline activities are subsistence-driven, net positive community impacts are demonstrated",  0],
        ["e" , "e. NPV from project activities is expected to be between 20% and up to 50% more profitable than the most profitable alternative land use activity",  -2],
        ["f" , "f. NPV from project activities is expected to be at least 50% more profitable than the most profitable alternative land use activity",  -4],
        ["g" , "g. Mitigation: Project proponent is a non-profit organization",  -2],
        ["h" , "h. Mitigation: Project is protected by legally binding commitment (see Section 2.2.4) to continue management practices that protect the credited carbon stocks over the length of the project crediting period", -2],
        //Total Opportunity Cost (OC) [as applicable (a, b, c, d, e, or f) + "g + h or i)]
    ];


var countryList = [["id", "iso2Code", "name"], ["ABW", "AW", "Aruba"], ["AFG", "AF", "Afghanistan"], ["AFR", "A9", "Africa"], ["AGO", "AO", "Angola"], ["ALB", "AL", "Albania"], ["AND", "AD", "Andorra"], ["ANR", "L5", "Andean Region"], ["ARB", "1A", "Arab World"], ["ARE", "AE", "United Arab Emirates"], ["ARG", "AR", "Argentina"], ["ARM", "AM", "Armenia"], ["ASM", "AS", "American Samoa"], ["ATG", "AG", "Antigua and Barbuda"], ["AUS", "AU", "Australia"], ["AUT", "AT", "Austria"], ["AZE", "AZ", "Azerbaijan"], ["BDI", "BI", "Burundi"], ["BEL", "BE", "Belgium"], ["BEN", "BJ", "Benin"], ["BFA", "BF", "Burkina Faso"], ["BGD", "BD", "Bangladesh"], ["BGR", "BG", "Bulgaria"], ["BHR", "BH", "Bahrain"], ["BHS", "BS", "Bahamas, The"], ["BIH", "BA", "Bosnia and Herzegovina"], ["BLR", "BY", "Belarus"], ["BLZ", "BZ", "Belize"], ["BMU", "BM", "Bermuda"], ["BOL", "BO", "Bolivia"], ["BRA", "BR", "Brazil"], ["BRB", "BB", "Barbados"], ["BRN", "BN", "Brunei Darussalam"], ["BTN", "BT", "Bhutan"], ["BWA", "BW", "Botswana"], ["CAA", "C9", "Sub-Saharan Africa (IFC classification)"], ["CAF", "CF", "Central African Republic"], ["CAN", "CA", "Canada"], ["CEA", "C4", "East Asia and the Pacific (IFC classification)"], ["CEU", "C5", "Europe and Central Asia (IFC classification)"], ["CHE", "CH", "Switzerland"], ["CHI", "JG", "Channel Islands"], ["CHL", "CL", "Chile"], ["CHN", "CN", "China"], ["CIV", "CI", "Cote d'Ivoire"], ["CLA", "C6", "Latin America and the Caribbean (IFC classification)"], ["CME", "C7", "Middle East and North Africa (IFC classification)"], ["CMR", "CM", "Cameroon"], ["COD", "CD", "Congo, Dem. Rep."], ["COG", "CG", "Congo, Rep."], ["COL", "CO", "Colombia"], ["COM", "KM", "Comoros"], ["CPV", "CV", "Cabo Verde"], ["CRI", "CR", "Costa Rica"], ["CSA", "C8", "South Asia (IFC classification)"], ["CSS", "S3", "Caribbean small states"], ["CUB", "CU", "Cuba"], ["CUW", "CW", "Curacao"], ["CYM", "KY", "Cayman Islands"], ["CYP", "CY", "Cyprus"], ["CZE", "CZ", "Czech Republic"], ["DEU", "DE", "Germany"], ["DJI", "DJ", "Djibouti"], ["DMA", "DM", "Dominica"], ["DNK", "DK", "Denmark"], ["DOM", "DO", "Dominican Republic"], ["DZA", "DZ", "Algeria"], ["EAP", "4E", "East Asia & Pacific (developing only)"], ["EAS", "Z4", "East Asia & Pacific (all income levels)"], ["ECA", "7E", "Europe & Central Asia (developing only)"], ["ECS", "Z7", "Europe & Central Asia (all income levels)"], ["ECU", "EC", "Ecuador"], ["EGY", "EG", "Egypt, Arab Rep."], ["EMU", "XC", "Euro area"], ["ERI", "ER", "Eritrea"], ["ESP", "ES", "Spain"], ["EST", "EE", "Estonia"], ["ETH", "ET", "Ethiopia"], ["EUU", "EU", "European Union"], ["FIN", "FI", "Finland"], ["FJI", "FJ", "Fiji"], ["FRA", "FR", "France"], ["FRO", "FO", "Faeroe Islands"], ["FSM", "FM", "Micronesia, Fed. Sts."], ["GAB", "GA", "Gabon"], ["GBR", "GB", "United Kingdom"], ["GEO", "GE", "Georgia"], ["GHA", "GH", "Ghana"], ["GIN", "GN", "Guinea"], ["GMB", "GM", "Gambia, The"], ["GNB", "GW", "Guinea-Bissau"], ["GNQ", "GQ", "Equatorial Guinea"], ["GRC", "GR", "Greece"], ["GRD", "GD", "Grenada"], ["GRL", "GL", "Greenland"], ["GTM", "GT", "Guatemala"], ["GUM", "GU", "Guam"], ["GUY", "GY", "Guyana"], ["HIC", "XD", "High income"], ["HKG", "HK", "Hong Kong SAR, China"], ["HND", "HN", "Honduras"], ["HPC", "XE", "Heavily indebted poor countries (HIPC)"], ["HRV", "HR", "Croatia"], ["HTI", "HT", "Haiti"], ["HUN", "HU", "Hungary"], ["IDN", "ID", "Indonesia"], ["IMN", "IM", "Isle of Man"], ["IND", "IN", "India"], ["INX", "XY", "Not classified"], ["IRL", "IE", "Ireland"], ["IRN", "IR", "Iran, Islamic Rep."], ["IRQ", "IQ", "Iraq"], ["ISL", "IS", "Iceland"], ["ISR", "IL", "Israel"], ["ITA", "IT", "Italy"], ["JAM", "JM", "Jamaica"], ["JOR", "JO", "Jordan"], ["JPN", "JP", "Japan"], ["KAZ", "KZ", "Kazakhstan"], ["KEN", "KE", "Kenya"], ["KGZ", "KG", "Kyrgyz Republic"], ["KHM", "KH", "Cambodia"], ["KIR", "KI", "Kiribati"], ["KNA", "KN", "St. Kitts and Nevis"], ["KOR", "KR", "Korea, Rep."], ["KSV", "KV", "Kosovo"], ["KWT", "KW", "Kuwait"], ["LAC", "XJ", "Latin America & Caribbean (developing only)"], ["LAO", "LA", "Lao PDR"], ["LBN", "LB", "Lebanon"], ["LBR", "LR", "Liberia"], ["LBY", "LY", "Libya"], ["LCA", "LC", "St. Lucia"], ["LCN", "ZJ", "Latin America & Caribbean (all income levels)"], ["LCR", "L4", "Latin America and the Caribbean"], ["LDC", "XL", "Least developed countries: UN classification"], ["LIC", "XM", "Low income"], ["LIE", "LI", "Liechtenstein"], ["LKA", "LK", "Sri Lanka"], ["LMC", "XN", "Lower middle income"], ["LMY", "XO", "Low & middle income"], ["LSO", "LS", "Lesotho"], ["LTU", "LT", "Lithuania"], ["LUX", "LU", "Luxembourg"], ["LVA", "LV", "Latvia"], ["MAC", "MO", "Macao SAR, China"], ["MAF", "MF", "St. Martin (French part)"], ["MAR", "MA", "Morocco"], ["MCA", "L8", "Mexico and Central America"], ["MCO", "MC", "Monaco"], ["MDA", "MD", "Moldova"], ["MDG", "MG", "Madagascar"], ["MDV", "MV", "Maldives"], ["MEA", "ZQ", "Middle East & North Africa (all income levels)"], ["MEX", "MX", "Mexico"], ["MHL", "MH", "Marshall Islands"], ["MIC", "XP", "Middle income"], ["MKD", "MK", "Macedonia, FYR"], ["MLI", "ML", "Mali"], ["MLT", "MT", "Malta"], ["MMR", "MM", "Myanmar"], ["MNA", "XQ", "Middle East & North Africa (developing only)"], ["MNE", "ME", "Montenegro"], ["MNG", "MN", "Mongolia"], ["MNP", "MP", "Northern Mariana Islands"], ["MOZ", "MZ", "Mozambique"], ["MRT", "MR", "Mauritania"], ["MUS", "MU", "Mauritius"], ["MWI", "MW", "Malawi"], ["MYS", "MY", "Malaysia"], ["NAC", "XU", "North America"], ["NAF", "M2", "North Africa"], ["NAM", "NA", "Namibia"], ["NCL", "NC", "New Caledonia"], ["NER", "NE", "Niger"], ["NGA", "NG", "Nigeria"], ["NIC", "NI", "Nicaragua"], ["NLD", "NL", "Netherlands"], ["NOC", "XR", "High income: nonOECD"], ["NOR", "NO", "Norway"], ["NPL", "NP", "Nepal"], ["NZL", "NZ", "New Zealand"], ["OEC", "XS", "High income: OECD"], ["OED", "OE", "OECD members"], ["OMN", "OM", "Oman"], ["OSS", "S4", "Other small states"], ["PAK", "PK", "Pakistan"], ["PAN", "PA", "Panama"], ["PER", "PE", "Peru"], ["PHL", "PH", "Philippines"], ["PLW", "PW", "Palau"], ["PNG", "PG", "Papua New Guinea"], ["POL", "PL", "Poland"], ["PRI", "PR", "Puerto Rico"], ["PRK", "KP", "Korea, Dem. Rep."], ["PRT", "PT", "Portugal"], ["PRY", "PY", "Paraguay"], ["PSE", "PS", "West Bank and Gaza"], ["PSS", "S2", "Pacific island small states"], ["PYF", "PF", "French Polynesia"], ["QAT", "QA", "Qatar"], ["ROU", "RO", "Romania"], ["RUS", "RU", "Russian Federation"], ["RWA", "RW", "Rwanda"], ["SAS", "8S", "South Asia"], ["SAU", "SA", "Saudi Arabia"], ["SCE", "L7", "Southern Cone Extended"], ["SDN", "SD", "Sudan"], ["SEN", "SN", "Senegal"], ["SGP", "SG", "Singapore"], ["SLB", "SB", "Solomon Islands"], ["SLE", "SL", "Sierra Leone"], ["SLV", "SV", "El Salvador"], ["SMR", "SM", "San Marino"], ["SOM", "SO", "Somalia"], ["SRB", "RS", "Serbia"], ["SSA", "ZF", "Sub-Saharan Africa (developing only)"], ["SSD", "SS", "South Sudan"], ["SSF", "ZG", "Sub-Saharan Africa (all income levels)"], ["SST", "S1", "Small states"], ["STP", "ST", "Sao Tome and Principe"], ["SUR", "SR", "Suriname"], ["SVK", "SK", "Slovak Republic"], ["SVN", "SI", "Slovenia"], ["SWE", "SE", "Sweden"], ["SWZ", "SZ", "Swaziland"], ["SXM", "SX", "Sint Maarten (Dutch part)"], ["SXZ", "A4", "Sub-Saharan Africa excluding South Africa"], ["SYC", "SC", "Seychelles"], ["SYR", "SY", "Syrian Arab Republic"], ["TCA", "TC", "Turks and Caicos Islands"], ["TCD", "TD", "Chad"], ["TGO", "TG", "Togo"], ["THA", "TH", "Thailand"], ["TJK", "TJ", "Tajikistan"], ["TKM", "TM", "Turkmenistan"], ["TLS", "TL", "Timor-Leste"], ["TON", "TO", "Tonga"], ["TTO", "TT", "Trinidad and Tobago"], ["TUN", "TN", "Tunisia"], ["TUR", "TR", "Turkey"], ["TUV", "TV", "Tuvalu"], ["TZA", "TZ", "Tanzania"], ["UGA", "UG", "Uganda"], ["UKR", "UA", "Ukraine"], ["UMC", "XT", "Upper middle income"], ["URY", "UY", "Uruguay"], ["USA", "US", "United States"], ["UZB", "UZ", "Uzbekistan"], ["VCT", "VC", "St. Vincent and the Grenadines"], ["VEN", "VE", "Venezuela, RB"], ["VIR", "VI", "Virgin Islands (U.S.)"], ["VNM", "VN", "Vietnam"], ["VUT", "VU", "Vanuatu"], ["WLD", "1W", "World"], ["WSM", "WS", "Samoa"], ["XZN", "A5", "Sub-Saharan Africa excluding South Africa and Nigeria"]];


//Table 8: Political Risk 
//Political Risk 
var politicalParameter =
    [
        ["a", "a. Governance score of less than -0.79", 6 ],
        ["b", "b. Governance score of -0.79 to less than -0.32", 4 ],
        ["c", "c. Governance score of -0.32 to less than 0.19", 2 ],
        ["d", "d. Governance score of 0.19 to less than 0.82", 1 ],
        ["e", "e. Governance score of 0.82 or higher", 0],
        ["f", "f. Mitigation: Country is implementing REDD+ Readiness or other activities, as set out in this Section 2.3.3.", -2] ,
    //Total Political (PC) [as applicable ((a, b, c, d or e) + f)] 
    //Total may not be less than zero. 
a) The country is receiving REDD+ Readiness funding from the World Bank Forest Carbon 
        Partnership Facility, UN-REDD or other bilateral or multilateral donors, and is 
        implementing a REDD+ policy framework covering key components such as GHG credit 
        ownership, clear government authority over REDD+ projects, and/or national 
        measurement, reporting and verification systems. 
        b) The country is participating in the CCBA/CARE REDD+ Social and Environmental 
        Standards initiative.2
 
        c) The jurisdiction in which the project is located is participating in the Governors’ Climate 
        and Forest Taskforce (GCF). 
        d) The country has an established national FSC or PEFC standards body. 
        e) The country has an established Designated National Authority under the CDM and has at 
        least one registered CDM Afforestation/Reforestation project. 