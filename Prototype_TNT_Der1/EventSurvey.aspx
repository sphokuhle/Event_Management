<%@ Page Title="" Language="C#" MasterPageFile="~/Eventrix.Master" AutoEventWireup="true" CodeBehind="EventSurvey.aspx.cs" Inherits="Prototype_TNT_Der1.EventSurvey" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="scripts/Survey/wufoo.js"></script>
    <link href="css/css/structure.css" rel="stylesheet" />
    <link href="css/css/form.css" rel="stylesheet" />
    <link href="css/css/theme.css" rel="stylesheet" />

        <section class="page-header-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                    </div>
                    <ol class="breadcrumb">
                        <li><a href="#">Home</a></li>
                        <li class="active">Event Survey</li>
                    </ol>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container-->
    </section>

        <div class="container">
        <div class="content-wrapper">
            <div class="inner-content">
                <div class="row">

                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading panel-heading-link" role="tab" id="headingOne">
                                <h2 class="panel-title">
                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Manage Events</a>
                                </h2>
                            </div>

    <div id="container" class="ltr">

<%--        <h1 id="logo">
            <a href="http://www.wufoo.com" title="Powered by Wufoo">Wufoo</a>
        </h1>--%>

        <form id="form1" name="form1" class="wufoo topLabel page" accept-charset="UTF-8" autocomplete="off" enctype="multipart/form-data" method="post" novalidate
            action="https://musiqmcman.wufoo.com/forms/zacyet61qbsw1s/#public">

            <header id="header" class="info">
                <h2 class="">Event Feedback: Post Event</h2>
                <div runat="server" id="eventDesc" class=""></div>
            </header>
            <ul>
                <li id="foli1" class="     ">
                               
                <li id="foli206" class="     ">
                    <fieldset>
                        <![if !IE | (gte IE 8)]>
                        <legend id="title206" class="desc notranslate">Was this the first time you attended one of our events?
</legend>
                        <![endif]>
                        <!--[if lt IE 8]>
<label id="title206" class="desc">
Was this the first time you attended one of our events?
</label>
<![endif]-->
                        <div>
                            <input runat="server" id="radioDefault_206" name="Field206" type="hidden" value="" />
                            <span>
                                <input runat="server" id="FT_Yes" name="Field206" type="radio" class="field radio" value="Yes" tabindex="39" onchange="" />
                                <label class="choice" for="FT_Yes">
                                    <span class="choice__text notranslate">Yes</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="FT_No" name="Field206" type="radio" class="field radio" value="No" tabindex="40" onchange="" />
                                <label class="choice" for="FT_No">
                                    <span class="choice__text notranslate">No</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                        </div>
                    </fieldset>
                </li>


                    <fieldset>
                        <![if !IE | (gte IE 8)]>
                        <legend id="title1" class="desc notranslate">Please rate your overall level of satisfaction with our event.
                        </legend>
                        <![endif]>
                        <!--[if lt IE 8]>
<label id="title1" class="desc">
Please rate your overall level of satisfaction with our event.
</label>
<![endif]-->
                    <%--    <div>
                            <input id="radioDefault_1" name="Field1" type="hidden" value="" />
                            <span>
                                <input runat="server" id="OS_VeryDisa" name="Field1" type="radio" class="field radio" value="Very Dissatisfied" tabindex="1" onchange="" checked="true" />
                                <label class="choice" for="OS_VeryDisa">
                                    <span class="choice__text notranslate">Very Dissatisfied</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="OS_Disa" name="Field1" type="radio" class="field radio" value="Dissatisfied" tabindex="2" onchange="" />
                                <label class="choice" for="OS_Disa">
                                    <span class="choice__text notranslate">Dissatisfied</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="OS_Neutral" name="Field1" type="radio" class="field radio" value="Neutral" tabindex="3" onchange="" />
                                <label class="choice" for="OS_Neutral">
                                    <span class="choice__text notranslate">Neutral</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="OS_Satis" name="Field1" type="radio" class="field radio" value="Satisfied" tabindex="4" onchange="" />
                                <label class="choice" for="OS_Satis">
                                    <span class="choice__text notranslate">Satisfied</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="OS_VerySatis" name="Field1" type="radio" class="field radio" value="Very Satisfied" tabindex="5" onchange="" />
                                <label class="choice" for="OS_VerySatis">
                                    <span class="choice__text notranslate">Very Satisfied</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                        </div>--%>
                    </fieldset>
                </li>
                <li id="foli3" class="likert notranslate
col5
 ">
                    <table cellspacing="0">
                        <caption id="title3">
                            Please rate your overall level of satisfaction with the following aspects of our event.
                        </caption>
                        <thead>
                            <tr>
                                <th>&nbsp;</th>
                                <td>Very Dissatisfied</td>
                                <td>Dissatisfied</td>
                                <td>Neutral</td>
                                <td>Satisfied</td>
                                <td>Very Satisfied</td>
                            </tr>
                        </thead>
                        <tbody>
                             <tr class="statement2">
                                <th>
                                    <label for="Field3">Overall Satisfaction</label></th>
                                <td title="Very Dissatisfied">
                                    <input runat="server" id="OS_VeryDisa" name="Field3" type="radio" tabindex="1" value="Very Dissatisfied" checked="true" />
                                    <label for="OS_VeryDisa">1</label>
                                </td>
                                <td title="Dissatisfied">
                                    <input runat="server" id="OS_Disa" name="Field3" type="radio" tabindex="2" value="Dissatisfied" />
                                    <label for="OS_Disa">2</label>
                                </td>
                                <td title="Neutral">
                                    <input runat="server" id="OS_Neutral" name="Field3" type="radio" tabindex="3" value="Neutral" />
                                    <label for="OS_Neutral">3</label>
                                </td>
                                <td title="Satisfied">
                                    <input runat="server" id="OS_Satis" name="Field3" type="radio" tabindex="4" value="Satisfied" />
                                    <label for="OS_Satis">4</label>
                                </td>
                                <td title="Very Satisfied">
                                    <input runat="server" id="OS_VerySatis" name="Field3" type="radio" tabindex="5" value="Very Satisfied" />
                                    <label for="OS_VerySatis">5</label>
                                </td>
                            </tr>

                            <tr class="statement3">
                                <th>
                                    <label for="Field3">Date</label></th>
                                <td title="Very Dissatisfied">
                                    <input runat="server" id="Date_VeryDis" name="Field3" type="radio" tabindex="6" value="Very Dissatisfied" checked="true" />
                                    <label for="Date_VeryDis">1</label>
                                </td>
                                <td title="Dissatisfied">
                                    <input runat="server" id="Date_Disat" name="Field3" type="radio" tabindex="7" value="Dissatisfied" />
                                    <label for="Date_Disat">2</label>
                                </td>
                                <td title="Neutral">
                                    <input runat="server" id="Date_Neutral" name="Field3" type="radio" tabindex="8" value="Neutral" />
                                    <label for="Date_Neutral">3</label>
                                </td>
                                <td title="Satisfied">
                                    <input runat="server" id="Date_Satis" name="Field3" type="radio" tabindex="9" value="Satisfied" />
                                    <label for="Date_Satis">4</label>
                                </td>
                                <td title="Very Satisfied">
                                    <input runat="server" id="Date_VerySatis" name="Field3" type="radio" tabindex="10" value="Very Satisfied" />
                                    <label for="Date_VerySatis">5</label>
                                </td>
                            </tr>
                            <tr class="alt statement4">
                                <th>
                                    <label for="Field4">Location</label></th>
                                <td title="Very Dissatisfied">
                                    <input runat="server" id="Loc_VeryDisat" name="Field4" type="radio" tabindex="11" value="Very Dissatisfied" checked="true" />
                                    <label for="Loc_VeryDisat">1</label>
                                </td>
                                <td title="Dissatisfied">
                                    <input runat="server" id="Loc_Disatis" name="Field4" type="radio" tabindex="12" value="Dissatisfied" />
                                    <label for="Loc_Disatis">2</label>
                                </td>
                                <td title="Neutral">
                                    <input runat="server" id="Loc_Neutral" name="Field4" type="radio" tabindex="13" value="Neutral" />
                                    <label for="Loc_Neutral">3</label>
                                </td>
                                <td title="Satisfied">
                                    <input runat="server" id="Loc_Satis" name="Field4" type="radio" tabindex="14" value="Satisfied" />
                                    <label for="Loc_Satis">4</label>
                                </td>
                                <td title="Very Satisfied">
                                    <input runat="server" id="Loc_VerySatis" name="Field4" type="radio" tabindex="15" value="Very Satisfied" />
                                    <label for="Loc_VerySatis">5</label>
                                </td>
                            </tr>
                            <tr class="statement5">
                                <th>
                                    <label for="Field5">Sessions</label></th>
                                <td title="Very Dissatisfied">
                                    <input runat="server" id="Ses_VeryDis" name="Field5" type="radio" tabindex="16" value="Very Dissatisfied" checked="true" />
                                    <label for="Ses_VeryDis">1</label>
                                </td>
                                <td title="Dissatisfied">
                                    <input runat="server" id="Ses_Dis" name="Field5" type="radio" tabindex="17" value="Dissatisfied" />
                                    <label for="Ses_Dis">2</label>
                                </td>
                                <td title="Neutral">
                                    <input runat="server" id="Ses_Neutral" name="Field5" type="radio" tabindex="18" value="Neutral" />
                                    <label for="Ses_Neutral">3</label>
                                </td>
                                <td title="Satisfied">
                                    <input runat="server" id="Ses_Satis" name="Field5" type="radio" tabindex="19" value="Satisfied" />
                                    <label for="Ses_Satis">4</label>
                                </td>
                                <td title="Very Satisfied">
                                    <input runat="server" id="Ses_VerySatis" name="Field5" type="radio" tabindex="20" value="Very Satisfied" />
                                    <label for="Ses_VerySatis">5</label>
                                </td>
                            </tr>
                            <tr class="alt statement6">
                                <th>
                                    <label for="Field6">Speakers</label></th>
                                <td title="Very Dissatisfied">
                                    <input runat="server" id="Spk_VeryDisat" name="Field6" type="radio" tabindex="21" value="Very Dissatisfied" checked="true" />
                                    <label for="Spk_VeryDisat">1</label>
                                </td>
                                <td title="Dissatisfied">
                                    <input runat="server" id="Spk_Dis" name="Field6" type="radio" tabindex="22" value="Dissatisfied" />
                                    <label for="Spk_Dis">2</label>
                                </td>
                                <td title="Neutral">
                                    <input runat="server" id="Spk_Neutral" name="Field6" type="radio" tabindex="23" value="Neutral" />
                                    <label for="Spk_Neutral">3</label>
                                </td>
                                <td title="Satisfied">
                                    <input runat="server" id="Spk_Satis" name="Field6" type="radio" tabindex="24" value="Satisfied" />
                                    <label for="Spk_Satis">4</label>
                                </td>
                                <td title="Very Satisfied">
                                    <input runat="server" id="Spk_VerySatis" name="Field6" type="radio" tabindex="25" value="Very Satisfied" />
                                    <label for="Spk_VerySatis">5</label>
                                </td>
                            </tr>
                            <tr class="statement7">
                                <th>
                                    <label for="Field7">Vendors</label></th>
                                <td title="Very Dissatisfied">
                                    <input runat="server" id="Ven_VeryDis" name="Field7" type="radio" tabindex="26" value="Very Dissatisfied" checked="true" />
                                    <label for="Ven_VeryDis">1</label>
                                </td>
                                <td title="Dissatisfied">
                                    <input runat="server" id="Ven_Dis" name="Field7" type="radio" tabindex="27" value="Dissatisfied" />
                                    <label for="Ven_Dis">2</label>
                                </td>
                                <td title="Neutral">
                                    <input runat="server" id="Ven_Neutral" name="Field7" type="radio" tabindex="28" value="Neutral" />
                                    <label for="Ven_Neutral">3</label>
                                </td>
                                <td title="Satisfied">
                                    <input runat="server" id="Ven_Satis" name="Field7" type="radio" tabindex="29" value="Satisfied" />
                                    <label for="Ven_Satis">4</label>
                                </td>
                                <td title="Very Satisfied">
                                    <input runat="server" id="Ven_VerySatis" name="Field7" type="radio" tabindex="30" value="Very Satisfied" />
                                    <label for="Ven_VerySatis">5</label>
                                </td>
                            </tr>
                            <tr class="alt statement8">
                                <th>
                                    <label for="Field8">Food</label></th>
                                <td title="Very Dissatisfied">
                                    <input runat="server" id="Fd_VeryDis" name="Field8" type="radio" tabindex="31" value="Very Dissatisfied" checked="true" />
                                    <label for="Fd_VeryDis">1</label>
                                </td>
                                <td title="Dissatisfied">
                                    <input runat="server" id="Fd_Dis" name="Field8" type="radio" tabindex="32" value="Dissatisfied" />
                                    <label for="Fd_Dis">2</label>
                                </td>
                                <td title="Neutral">
                                    <input runat="server" id="Fd_Neutral" name="Field8" type="radio" tabindex="33" value="Neutral" />
                                    <label for="Fd_Neutral">3</label>
                                </td>
                                <td title="Satisfied">
                                    <input runat="server" id="Fd_Satis" name="Field8" type="radio" tabindex="34" value="Satisfied" />
                                    <label for="Fd_Satis">4</label>
                                </td>
                                <td title="Very Satisfied">
                                    <input runat="server" id="Fd_VerySatis" name="Field8" type="radio" tabindex="35" value="Very Satisfied" />
                                    <label for="Fd_VerySatis">5</label>
                                </td>
                            </tr>
                            <tr class="alt statememnt8">

                            </tr>
                          
                        </tbody>
                    </table>
                </li>

                <li id="foli308" class="     ">
                    <fieldset>
                        <![if !IE | (gte IE 8)]>
                        <legend id="title308" class="desc notranslate">How likely are you to attend one of our future events?
</legend>
                        <![endif]>
                        <!--[if lt IE 8]>
<label id="title308" class="desc">
How likely are you to attend one of our future events?
</label>
<![endif]-->
                        <div>
                            <input runat="server" id="radioDefault_308" name="Field308" type="hidden" value="" />
                            <span>
                                <input runat="server" id="Future_NotLikelyAtAll" name="Field308" type="radio" class="field radio" value="Not Likely At All" tabindex="41" onchange="" />
                                <label class="choice" for="Future_NotLikelyAtAll">
                                    <span class="choice__text notranslate">Not Likely At All</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="Future_NotLikely" name="Field308" type="radio" class="field radio" value="Not Likely" tabindex="42" onchange="" />
                                <label class="choice" for="Future_NotLikely">
                                    <span class="choice__text notranslate">Not Likely</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="Future_Neutral" name="Field308" type="radio" class="field radio" value="Neutral" tabindex="43" onchange="" />
                                <label class="choice" for="Future_Neutral">
                                    <span class="choice__text notranslate">Neutral</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="Future_Likely" name="Field308" type="radio" class="field radio" value="Likely" tabindex="44" onchange="" />
                                <label class="choice" for="Future_Likely">
                                    <span class="choice__text notranslate">Likely</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="Future_VeryLikely" name="Field308" type="radio" class="field radio" value="Very Likely" tabindex="45" onchange="" />
                                <label class="choice" for="Future_VeryLikely">
                                    <span class="choice__text notranslate">Very Likely</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                        </div>
                    </fieldset>
                </li>
                <li id="foli309" class="     ">
                    <fieldset>
                        <![if !IE | (gte IE 8)]>
                        <legend id="title309" class="desc notranslate">How likely are you to recommend our events to a friend or colleague?
</legend>
                        <![endif]>
                        <!--[if lt IE 8]>
<label id="title309" class="desc">
How likely are you to recommend our events to a friend or colleague?
</label>
<![endif]-->
                        <div>
                            <input runat="server" id="radioDefault_309" name="Field309" type="hidden" value="" />
                            <span>
                                <input runat="server" id="RecFriend_NotLikelyAtAll" name="Field309" type="radio" class="field radio" value="Not Likely At All" tabindex="46" onchange="" />
                                <label class="choice" for="RecFriend_NotLikelyAtAll">
                                    <span class="choice__text notranslate">Not Likely At All</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="RecFriend_NotLikely" name="Field309" type="radio" class="field radio" value="Not Likely" tabindex="47" onchange="" />
                                <label class="choice" for="RecFriend_NotLikely">
                                    <span class="choice__text notranslate">Not Likely</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="RecFriend_Neutral" name="Field309" type="radio" class="field radio" value="Neutral" tabindex="48" onchange="" />
                                <label class="choice" for="RecFriend_Neutral">
                                    <span class="choice__text notranslate">Neutral</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="RecFriend_Likely" name="Field309" type="radio" class="field radio" value="Likely" tabindex="49" onchange="" />
                                <label class="choice" for="RecFriend_Likely">
                                    <span class="choice__text notranslate">Likely</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                            <span>
                                <input runat="server" id="RecFriend_VeryLikely" name="Field309" type="radio" class="field radio" value="Very Likely" tabindex="50" onchange="" />
                                <label class="choice" for="RecFriend_VeryLikely">
                                    <span class="choice__text notranslate">Very Likely</span>
                                    <span class="choice__qty"></span>
                                </label>
                            </span>
                        </div>
                    </fieldset>
                </li>
     <%--           <li id="foli310"
                    class="notranslate      ">
                    <label class="desc" id="title310" for="Field310">
                        Are there any other comments or suggestions you'd like to make?
                    </label>

                    <div>
                        <textarea runat="server" id="txtComments"
                            name="Field310"
                            class="field textarea medium"
                            spellcheck="true"
                            rows="10" cols="50"
                            tabindex="51"
                            onkeyup="validateRange(310, 'word');"
                            placeholder=""></textarea>

                        <label for="txtComments">Maximum Allowed:
                            <var id="rangeMaxMsg310">200</var>
                            words.&nbsp;&nbsp;&nbsp; <em class="currently">Currently Used:
                                <var id="rangeUsedMsg310">0</var>
                                words.</em></label>
                    </div>
                </li>--%>
                <li class="buttons ">
                    <div>

<%--                        <input id="saveForm" name="saveForm" class="btTxt submit"
                            type="submit" value="Submit" />--%>
                       <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
                        <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </li>

                <li class="hide">
                    <label for="comment">Do Not Fill This Out</label>
                    <textarea name="comment" id="comment" rows="1" cols="1"></textarea>
                    <input type="hidden" id="idstamp" name="idstamp" value="9ljCcTsuwdaVpSQgdJGHu+kS3Esd4micQVJY5cCsLsQ=" />
                </li>
            </ul>
        </form>


    </div><!--container-->

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>

</asp:Content>
