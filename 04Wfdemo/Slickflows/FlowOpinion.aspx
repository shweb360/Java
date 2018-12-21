<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowOpinion.aspx.cs" Inherits="Slickflow.WebDemo.Slickflows.FlowOpinion" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Skin/default.css" rel="stylesheet" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/layout.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--列表-->

        <table width="100%" border="1" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th align="center" width="12%">科室</th>
                <th align="center" width="8%">办理人</th>
                <th align="center" width="20%">办理意见</th>
                <th align="center" width="10%">附件</th>
                <th align="center" width="10%">办理时间</th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" Visible="false">
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Eval("ActivityName") %></td>
                        <td align="center"><%#Eval("ChangedUserName") %></td>
                        <td align="center"><%#Eval("Remark") %></td>
                         <td align="center"><a href="<%#Eval("FilePath").ToString().Replace("~","")%>">下载</a></td>
                        <td align="center"><%#Eval("ChangedTime") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
             <asp:Repeater ID="Repeater2" runat="server" Visible="false">
                <ItemTemplate>
                    <tr>
                        <td align="center"><%#Eval("ActivityName") %></td>
                        <td align="center"><%#Eval("ChangedUserName") %></td>
                        <td align="center"><%#Eval("Remark") %></td>
                         <td align="center"><%#Getpath(Eval("UploadFileID").ToString())%></td>
                        <td align="center"><%#Eval("ChangedTime") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>


    </form>
</body>
</html>
