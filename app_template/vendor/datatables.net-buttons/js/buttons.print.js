!function(t){"function"==typeof define&&define.amd?define(["jquery","datatables.net","datatables.net-buttons"],function(e){return t(e,window,document)}):"object"==typeof exports?module.exports=function(e,n){return e||(e=window),n&&n.fn.dataTable||(n=require("datatables.net")(e,n).$),n.fn.dataTable.Buttons||require("datatables.net-buttons")(e,n),t(n,e,e.document)}:t(jQuery,window,document)}(function(t,e,n,o){"use strict";var a=t.fn.dataTable,r=n.createElement("a"),i=function(t){r.href=t;var e=r.host;return-1===e.indexOf("/")&&0!==r.pathname.indexOf("/")&&(e+="/"),r.protocol+"//"+e+r.pathname+r.search};return a.ext.buttons.print={className:"buttons-print",text:function(t){return t.i18n("buttons.print","Print")},action:function(n,o,a,r){var d=o.buttons.exportData(t.extend({decodeEntities:!1},r.exportOptions)),u=o.buttons.exportInfo(r),s=function(t,e){for(var n="<tr>",o=0,a=t.length;o<a;o++)n+="<"+e+">"+t[o]+"</"+e+">";return n+"</tr>"},c='<table class="'+o.table().node().className+'">';r.header&&(c+="<thead>"+s(d.header,"th")+"</thead>"),c+="<tbody>";for(var f=0,l=d.body.length;f<l;f++)c+=s(d.body[f],"td");c+="</tbody>",r.footer&&d.footer&&(c+="<tfoot>"+s(d.footer,"th")+"</tfoot>"),c+="</table>";var m=e.open("","");m.document.close();var b="<title>"+u.title+"</title>";t("style, link").each(function(){var e;b+=("link"===(e=t(this).clone()[0]).nodeName.toLowerCase()&&(e.href=i(e.href)),e.outerHTML)});try{m.document.head.innerHTML=b}catch(n){t(m.document.head).html(b)}m.document.body.innerHTML="<h1>"+u.title+"</h1><div>"+(u.messageTop||"")+"</div>"+c+"<div>"+(u.messageBottom||"")+"</div>",t(m.document.body).addClass("dt-print-view"),t("img",m.document.body).each(function(t,e){e.setAttribute("src",i(e.getAttribute("src")))}),r.customize&&r.customize(m),setTimeout(function(){r.autoPrint&&(m.print(),m.close())},1e3)},title:"*",messageTop:"*",messageBottom:"*",exportOptions:{},header:!0,footer:!1,autoPrint:!0,customize:null},a.Buttons});