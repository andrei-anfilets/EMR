!function(e,t,i){"$:nomunge";var n,a=[],r=e.resize=e.extend(e.resize,{}),o=!1,s="setTimeout",u="resize",h=u+"-special-event",m="pendingDelay",l="activeDelay",c="throttleWindow";function d(i){!0===o&&(o=i||1);for(var s=a.length-1;s>=0;s--){var l=e(a[s]);if(l[0]==t||l.is(":visible")){var c=l.width(),f=l.height(),g=l.data(h);!g||c===g.w&&f===g.h||(l.trigger(u,[g.w=c,g.h=f]),o=i||!0)}else(g=l.data(h)).w=0,g.h=0}null!==n&&(o&&(null==i||i-o<1e3)?n=t.requestAnimationFrame(d):(n=setTimeout(d,r[m]),o=!1))}r[m]=200,r[l]=20,r[c]=!0,e.event.special[u]={setup:function(){if(!r[c]&&this[s])return!1;var t=e(this);a.push(this),t.data(h,{w:t.width(),h:t.height()}),1===a.length&&(n=i,d())},teardown:function(){if(!r[c]&&this[s])return!1;for(var t=e(this),i=a.length-1;i>=0;i--)if(a[i]==this){a.splice(i,1);break}t.removeData(h),a.length||(o?cancelAnimationFrame(n):clearTimeout(n),n=null)},add:function(t){if(!r[c]&&this[s])return!1;var n;function a(t,a,r){var o=e(this),s=o.data(h)||{};s.w=a!==i?a:o.width(),s.h=r!==i?r:o.height(),n.apply(this,arguments)}if(e.isFunction(t))return n=t,a;n=t.handler,t.handler=a}},t.requestAnimationFrame||(t.requestAnimationFrame=t.webkitRequestAnimationFrame||t.mozRequestAnimationFrame||t.oRequestAnimationFrame||t.msRequestAnimationFrame||function(e,i){return t.setTimeout(function(){e((new Date).getTime())},r[l])}),t.cancelAnimationFrame||(t.cancelAnimationFrame=t.webkitCancelRequestAnimationFrame||t.mozCancelRequestAnimationFrame||t.oCancelRequestAnimationFrame||t.msCancelRequestAnimationFrame||clearTimeout)}(jQuery,this),jQuery.plot.plugins.push({init:function(e){function t(){var t=e.getPlaceholder();0!=t.width()&&0!=t.height()&&(e.resize(),e.setupGrid(),e.draw())}e.hooks.bindEvents.push(function(e,i){e.getPlaceholder().resize(t)}),e.hooks.shutdown.push(function(e,i){e.getPlaceholder().unbind("resize",t)})},options:{},name:"resize",version:"1.0"});