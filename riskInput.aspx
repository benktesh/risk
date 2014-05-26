<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="riskInput.aspx.cs" Inherits="Risk.WebForm1"%>
    
    
   
    

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Input Form</title>
<link href="StyleSheet.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.0.js"></script>
    <script src="Scripts/jquery-2.1.0.intellisense.js"></script>
    <script src="Scripts/vcsRiskVariable.js"></script>
    <script>
        $(document).ready(function ()
        {


          //  populateCountryDropDown();
            console.log($("#checkPostBack").val());
           
              //  alert($("#checkPostBack").val());
                for (var i = 1; i < 7; i++) {
                    var descriptionID = ("#projectManagementDescription" + i);
                    var valueID = ("#projectManagementValue" + i);
                    $(descriptionID).html(projectManagementParameter[i - 1][1]);
                    //$('#projectManagementValue1').html('-');

                    $(valueID).css("text-align", "center");
                    $(valueID).css("text-align", "center");
                    $('#CheckBox' + 1).css("text-align", "center");
                }

                for (var i = 0; i < financialViabilityParameter.length; i++) {
                    var descriptionID = ("#financialViabilityDescription" + (i + 1));
                    //console.log(descriptionID);
                    var valueID = ("#financialViabilityValue" + (i + 1));
                    $(descriptionID).html(financialViabilityParameter[i][1]);
                    $(valueID).css("text-align", "center");
                    $(valueID).css("text-align", "center");
                    $('#fvCheckBox' + 1).css("text-align", "center");
                }

                for (var i = 0; i < opportunityCostParameter.length; i++) {
                    var descriptionID = ("#opportunityCostDescription" + (i + 1));
                    //console.log(descriptionID);
                    var valueID = ("#opportunityCostValue" + (i + 1));
                    $(descriptionID).html(opportunityCostParameter[i][1]);
                    $(valueID).css("text-align", "center");
                    $(valueID).css("text-align", "center");
                }


                for (var i = 1; i <= politicalParameter.length; i++) {
                    var descriptionID = ("#politicalRiskDescription" + i);
                    var valueID = ("#politicalRiskValue" + i);
                    $(descriptionID).html(politicalParameter[i - 1][1]);
                    //$('#projectManagementValue1').html('-');

                    $(valueID).css("text-align", "center");
                    $(valueID).css("text-align", "center");
                    $('#CheckBox' + 1).css("text-align", "center");
                }

            
            /* If the postback is true, all the selected items must show value to it.
             * Else the value field can display default '-'.
             */
                if ($("#checkPostBack").val() == "true") {
                    functPM();
                    functFV();
                    functOC();
                }
             
                
           /*
            * On each click for events, calls a functions to update data.
            */
            $('.fvCheckBox').click(function () {
                functFV();
            });

            $('.pmCheckBox').click(function () {
                functPM();
               
               
            });
            $('#OpportunityCost').click(function () {
                functOC();
            });

            //This funciton toggles (hide/show) the risk components.
            $('a.aPM').click(function () {
                $('#ProjectManagement').toggle();
            });

            $('a.aFV').click(function () {
                $('#FinancialViability').toggle();
            });

            $('a.aOC').click(function () {
                $('#OpportunityCost').toggle();
            });

            $('a.aPR').click(function () {
                $('#PoliticalRisk').toggle();
            });


    


            $('#CheckBox2').click(function(){
                if ($('#CheckBox2').is(':checked')) {
                    $('#CheckBox3').attr('checked', false);
                }
               
            });
            $('#CheckBox3').click(function () {
                if ($('#CheckBox3').is(':checked')) {
                    $('#CheckBox2').attr('checked', false);
                }

            });

            $('#bgGetWBData').click(function () {
                alert($('#dropCountryList').selected.val());
            });
          
           
          

        });

       
    

        function myPrePostbackFunction()
        {
            
            $("#frmMain").submit(function (event) {
                alert(JSON.stringify(functPM()));
                $('#txtResult').val(JSON.stringify(functPM()));
               
            });
          

            /*
             * Psedudocode:
                    Get all the selected elements from Project Management
                    Map it with the datastrcuture
                    Make json object of id and value
                    Send 
             */
        }

        function functPM() {
            var totalPM = 0; var i = 0;
            var selectedPM = [];
            $(".pmCheckBox").each(function () {
                //console.log((this.id));
                var valueID = ("#projectManagementValue" + (i + 1));
                var chkbxId = '#' + this.id;
                //console.log($(chkbxId).is(':checked'));
                if ($(chkbxId).is(':checked')) {
                    totalPM = totalPM +
                         parseInt(projectManagementParameter[i][2]);
                    $(valueID).html(projectManagementParameter[i][2]);
                    selectedPM.push({
                        id: projectManagementParameter[i][0],
                        selectedValue: projectManagementParameter[i][2]
                        });
                }
                else {
                    $(valueID).html('-');
                }
                i++;
            });
            $('#totalPM').html(totalPM);
           // console.log('Total elements ' + i);
            return selectedPM;
        };

        function functFV() {
            var totalValue = 0; var i = 0; 
            $(".fvCheckBox").each(function () {
                //console.log((this.id));
                var valueID = ("#financialViabilityValue" + (i + 1));
                var chkbxId = '#' + this.id;
                //console.log($(chkbxId).is(':checked'));
                if ($(chkbxId).is(':checked')) {
                    totalValue = totalValue + 
                         parseInt(financialViabilityParameter[i][2]);
                    $(valueID).html(financialViabilityParameter[i][2]);
                }
                else {
                    $(valueID).html('-');
                }
                console.log('Value of i ' + i);
                i++;
            });
            $('#totalFV').html(totalValue < 0 ? 0 : totalValue); 
        };

        function functOC() {
            var totalOC = 0;
            var radioButtons = $(":radio[name='OC_AF_GRP']");
            var selectedIndex = radioButtons.index(radioButtons.filter(':checked'));

            //Clear values caused by previous selection.
            for (var i = 0; i < 6; i++) {
                $('#opportunityCostValue' + (i + 1)).html('-');
            }

            var valueID = ("#opportunityCostValue" + (selectedIndex + 1));
            if (selectedIndex >= 0) {
                totalOC = totalOC + parseInt(opportunityCostParameter[selectedIndex][2]);
                $(valueID).html(opportunityCostParameter[selectedIndex][2]);
            }
            else {
                $(valueID).html('-');
            }

            if ($('#ocCheckBox1').is(':checked')) {
                totalOC = totalOC +
                     parseInt(opportunityCostParameter[6][2]);
                $('#opportunityCostValue7').html(opportunityCostParameter[6][2]);
            }
            else {
                $('#opportunityCostValue7').html('-');
            }


            if ($('#CheckBox2').is(':checked')) {
              
                totalOC = totalOC +
                    parseInt(opportunityCostParameter[7][2]);
                $('#opportunityCostValue8').html(opportunityCostParameter[7][2]);
            }
            else {
                $('#opportunityCostValue8').html('-');
            }
            if ($('#CheckBox3').is(':checked')) {
               
                totalOC = totalOC +
                   parseInt(opportunityCostParameter[8][2]);
                $('#opportunityCostValue9').html(opportunityCostParameter[8][2]);
            } else {
                $('#opportunityCostValue9').html('-');
            }

           
            //The total must not be less than 0;
            totalOC < 0 ? 0 : totalOC;
            $('#totalOC').html(totalOC);
            //console.log('Total elements ' + i);

        };

      
        
       
            
        

    </script>
    </head>
<body>
    <form id="frmMain" runat="server">
        <div id="InternalRisk">
         <table style="width:800px">
            <tr>
                <td style="width:90%; border:none;">
                    <br />
                    <asp:DropDownList ID="dropCountryList"  runat="server" Height="27px" Width="115px">
                    </asp:DropDownList>
                    <asp:Button ID="bgGetWBData" runat="server" OnClick="bgGetWBData_Click" Text="Get WB WGI" Height="27px" />
                    <br />
                    <a href="#" class="aPM">Project Management</a> </td>
                <td id="totalPM" style="width:10%; border:none; text-align:center">0</td>
            </tr>
        </table>
        <br/>   

        <div id ="ProjectManagement">
        <table style="margin-left: 100px;">
            <tr>
                <td style="vertical-align: middle; text-align: center; width: 10%"><asp:CheckBox ID="pmCheckBox1" runat="server" /></td>
                <td id="projectManagementDescription1" style="width:80%"></td>
                <td id="projectManagementValue1" "width:10%">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center"><asp:CheckBox ID="pmCheckBox2" runat="server" /></td>
                <td id="projectManagementDescription2"></td>
                <td id="projectManagementValue2">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center"><asp:CheckBox ID="pmCheckBox3" runat="server" /></td>
                <td id="projectManagementDescription3"></td>
                <td id="projectManagementValue3">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center"><asp:CheckBox ID="pmCheckBox4" runat="server" /></td>
                <td id="projectManagementDescription4">huwa</td>
                <td id="projectManagementValue4">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center"><asp:CheckBox ID="pmCheckBox5" runat="server" /></td>
                <td id="projectManagementDescription5"></td>
                <td id="projectManagementValue5">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center"><asp:CheckBox ID="pmCheckBox6" runat="server" /></td>
                <td id="projectManagementDescription6"></td>
                <td id="projectManagementValue6">-</td>
            </tr>
        </table>
        <br />
        </div> 
        
        <table style="width:800px">
            <tr>
                <td style="width:90%; border:none;"><a href="#" class="aFV">Financial Viability</a> </td>
                <td id="totalFV" style="width:10%; border:none; text-align:center">0</td>
            </tr>
        </table> 
        <div id ="FinancialViability">
        <br/>   
    
        <table style="margin-left: 100px;">
            <tr>
              <td style="vertical-align: middle; text-align: center; width:10%">
                <asp:CheckBox ID="fvCheckBox1" runat="server" />
             </td>
              <td id="financialViabilityDescription1" style="width:80%"></td>
              <td id="financialViabilityValue1" "width:10%">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center" class="">
                <asp:CheckBox ID="fvCheckBox2" runat="server" />
                </td>
                <td id="financialViabilityDescription2"></td>
                <td id="financialViabilityValue2">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center" class="">
                    <asp:CheckBox ID="fvCheckBox3" runat="server" />
                </td>
                <td id="financialViabilityDescription3"></td>
                <td id="financialViabilityValue3">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center" class="">
                    <asp:CheckBox ID="fvCheckBox4" runat="server" />
                </td>
                <td id="financialViabilityDescription4">huwa</td>
                <td id="financialViabilityValue4">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:CheckBox ID="fvCheckBox5" runat="server" />
                </td>
                <td id="financialViabilityDescription5"></td>
                <td id="financialViabilityValue5">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:CheckBox ID="fvCheckBox6" runat="server" />
                </td>
                <td id="financialViabilityDescription6"></td>
                <td id="financialViabilityValue6">-</td>
            </tr>

              <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:CheckBox ID="fvCheckBox7" runat="server" />
                  </td>
                <td id="financialViabilityDescription7"></td>
                <td id="financialViabilityValue7">-</td>
            </tr>

              <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:CheckBox ID="fvCheckBox8" runat="server" />
                  </td>
                <td id="financialViabilityDescription8"></td>
                <td id="financialViabilityValue8">-</td>
            </tr>

              <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:CheckBox ID="fvCheckBox9" runat="server" />
                  </td>
                <td id="financialViabilityDescription9"></td>
                <td id="financialViabilityValue9">-</td>
            </tr>
        </table>
        </div>
        <br/>  
        
    <table style="width:800px">
    <tr>
        <td style="width:90%; border:none;"><a href="#" class="aOC">Opportunity Cost</a> </td>
        <td id="totalOC" style="width:10%; border:none; text-align:center">0</td>
        </tr>
     </table>
    <br/>        
        
    <div id ="OpportunityCost">
        <table style="margin-left: 100px;">
            <tr>
                <td style="vertical-align: middle; text-align: center; width:10%">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="OC_AF_GRP"/>
                </td>
                <td id="opportunityCostDescription1" style="width:80%"></td>
                <td id="opportunityCostValue1" "width:10%">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="OC_AF_GRP"   />
                </td>
                <td id="opportunityCostDescription2"></td>
                <td id="opportunityCostValue2">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="OC_AF_GRP"   />
                </td>
                <td id="opportunityCostDescription3"></td>
                <td id="opportunityCostValue3">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="OC_AF_GRP" />
                </td>
                <td id="opportunityCostDescription4"></td>
                <td id="opportunityCostValue4">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="OC_AF_GRP" />
                </td>
                <td id="opportunityCostDescription5"></td>
                <td id="opportunityCostValue5">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:RadioButton ID="RadioButton6" runat="server" GroupName="OC_AF_GRP" />
                </td>
                 <td id="opportunityCostDescription6"></td>
                <td id="opportunityCostValue6">-</td>
            </tr>

              <tr>
                <td style="vertical-align: middle; text-align: center;" colspan="3" class="Instruction">Check, if following mitigtation option is applicable:</td>
            </tr>

              <tr>
                <td style="vertical-align: middle; text-align: center"><asp:CheckBox ID="ocCheckBox1" runat="server" OnCheckedChanged="ocCheckBox1_CheckedChanged" /></td>
                <td id="opportunityCostDescription7"></td>
                <td id="opportunityCostValue7">-</td>
            </tr>

              <tr>
                <td style="vertical-align: middle; text-align: center;" colspan="3" class="Instruction">Select one from the mitigation options below:</td>
                
            </tr>

              <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="ocCheckBox2_CheckedChanged" />
                  </td>
               <td id="opportunityCostDescription8">&nbsp;</td>
                <td id="opportunityCostValue8">-</td>
            </tr>

              <tr>
                <td style="vertical-align: middle; text-align: center">
                    <asp:CheckBox ID="CheckBox3" runat="server" OnCheckedChanged="ocCheckBox3_CheckedChanged" />
                  </td>
               <td id="opportunityCostDescription9">&nbsp;</td>
                <td id="opportunityCostValue9">-</td>
            </tr>
     
        </table>
         </div> 
        <br />

        
        <table style="width:800px">
        <tr>
            <td style="width:90%; border:none;"><a href="#" class="aPR">Political Risk</a> </td>
            <td id="totalPR" style="width:10%; border:none; text-align:center">0</td>
            </tr>
         </table>
         <br/>        
        
        <div id ="PoliticalRisk">
        <table style="margin-left: 100px;">
            <tr>
                <td style="vertical-align: middle; text-align: center; width:10%">
                    <asp:RadioButton ID="RadioButton_PR1" runat="server" GroupName="PR_AE_GRP"/>
                </td>
                <td id="politicalRiskDescription1" style="width:80%"></td>
                <td id="politicalRiskValue1" "width:10%">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center; width:10%">
                    <asp:RadioButton ID="RadioButton_PR2" runat="server" GroupName="PR_AE_GRP"/>
                </td>
                <td id="politicalRiskDescription2" style="width:80%"></td>
                <td id="politicalRiskValue2" "width:10%">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center; width:10%">
                    <asp:RadioButton ID="RadioButton_PR3" runat="server" GroupName="PR_AE_GRP"/>
                </td>
                <td id="politicalRiskDescription3" style="width:80%"></td>
                <td id="politicalRiskValue3" "width:10%">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center; width:10%">
                    <asp:RadioButton ID="RadioButton_PR4" runat="server" GroupName="PR_AE_GRP"/>
                </td>
                <td id="politicalRiskDescription4" style="width:80%"></td>
                <td id="politicalRiskValue4" "width:10%">-</td>
            </tr>

            <tr>
                <td style="vertical-align: middle; text-align: center; width:10%">
                    <asp:RadioButton ID="RadioButton_PR5" runat="server" GroupName="PR_AE_GRP"/>
                </td>
                <td id="politicalRiskDescription5" style="width:80%"></td>
                <td id="politicalRiskValue5" "width:10%">-</td>
            </tr>

           
            <tr>
                <td style="vertical-align: middle; text-align: center"><asp:CheckBox ID="prCheckBox1" runat="server" /></td>
                <td id="politicalRiskDescription6"></td>
                <td id="politicalRiskValue6">-</td>
            </tr>     
        </table>

    </div>

        <br />
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" OnClientClick="myPrePostbackFunction()" Text="Button" />
    <br />     

        <asp:TextBox ID="txtResult" runat="server">Result is here</asp:TextBox>

        <br />
        <asp:HiddenField ID="checkPostBack" runat="server" Value="&quot;false&quot;" />

    </div>

    </form>
</body>
</html>
