/* Copyright 2007-8 Google. */ (function() { function h(a){throw a;}
var i=void 0,k=!0,l=null,m=!1,r="",aa="\n",s=" ",ba='"',ca='", ',da='","groups":["reactions"]},"labels":[',ea='","groups":["reactions"]},{"url": "',fa='"}],"applicationId":34}',ga="$$$$",ha="(",ia="(\\d*)(\\D*)",ja=")",ka="*",la=".",na="0",oa=": ",pa="@",qa="Assertion failed",ra="Content-Type",sa="GET",ta="MSXML2.XMLHTTP",ua="MSXML2.XMLHTTP.3.0",va="MSXML2.XMLHTTP.6.0",wa="Microsoft.XMLHTTP",xa="POST",ya="[object Array]",za="[object Function]",Aa="[object Window]",Ba="]",Ca=']}],"applicationId":34}&token=',
Da="_",Ea="a",Fa="abort",Ga="application/x-www-form-urlencoded;charset=utf-8",u="array",Ha="call",Ia="click",Ja="complete",Ka="error",La="event",v="function",Ma="g",Na="http://www.blogger.com/reviews/json/aggregates",Oa="http://www.blogger.com/reviews/json/token",Pa="http://www.blogger.com/reviews/json/write",Qa="innerText",Ra="keypress",Sa="mouseout",Ta="mouseover",Ua="native code",Va="null",Wa="number",Xa="object",Ya="on",Za="ready",$a="readystatechange",ab='req={"annotations": [ {"replaceAllLabels":true,"entity": {"url": "',
bb='req={"applicationId":34}',cb='req={"entities":[{"url": "',db="rx-checked",eb="rx-count",fb="rx-holder",gb="rx-label",hb="rx-option",ib="rx-unchecked",jb="span",kb="splice",lb="string",mb="success",nb="timeout",ob="var ",pb="window",qb="withCredentials",w,rb=rb||{},x=this,sb=function(a,b,c){a=a.split(la);c=c||x;!(a[0]in c)&&c.execScript&&c.execScript(ob+a[0]);for(var d;a.length&&(d=a.shift());)!a.length&&b!==i?c[d]=b:c=c[d]?c[d]:c[d]={}},tb=function(){},y=function(a){var b=typeof a;if(b==Xa)if(a){if(a instanceof
Array)return u;if(a instanceof Object)return b;var c=Object.prototype.toString.call(a);if(c==Aa)return Xa;if(c==ya||typeof a.length==Wa&&"undefined"!=typeof a.splice&&"undefined"!=typeof a.propertyIsEnumerable&&!a.propertyIsEnumerable(kb))return u;if(c==za||"undefined"!=typeof a.call&&"undefined"!=typeof a.propertyIsEnumerable&&!a.propertyIsEnumerable(Ha))return v}else return Va;else if(b==v&&"undefined"==typeof a.call)return Xa;return b},z=function(a){var b=y(a);return b==u||b==Xa&&typeof a.length==
Wa},A=function(a){return typeof a==lb},B=function(a){return a[ub]||(a[ub]=++vb)},ub="closure_uid_"+Math.floor(2147483648*Math.random()).toString(36),vb=0,wb=function(a,b,c){return a.call.apply(a.bind,arguments)},xb=function(a,b,c){a||h(Error());if(2<arguments.length){var d=Array.prototype.slice.call(arguments,2);return function(){var c=Array.prototype.slice.call(arguments);Array.prototype.unshift.apply(c,d);return a.apply(b,c)}}return function(){return a.apply(b,arguments)}},C=function(a,b,c){C=Function.prototype.bind&&
-1!=Function.prototype.bind.toString().indexOf(Ua)?wb:xb;return C.apply(l,arguments)},yb=function(a,b){var c=Array.prototype.slice.call(arguments,1);return function(){var b=Array.prototype.slice.call(arguments);b.unshift.apply(b,c);return a.apply(this,b)}},E=function(a,b){function c(){}c.prototype=b.prototype;a.superClass_=b.prototype;a.prototype=new c};
Function.prototype.bind=Function.prototype.bind||function(a,b){if(1<arguments.length){var c=Array.prototype.slice.call(arguments,1);c.unshift(this,a);return C.apply(l,c)}return C(this,a)};Function.prototype.partial=function(a){var b=Array.prototype.slice.call(arguments);b.unshift(this,l);return C.apply(l,b)};var zb=function(a){Error.captureStackTrace?Error.captureStackTrace(this,zb):this.stack=Error().stack||r;a&&(this.message=String(a))};E(zb,Error);var Ab=function(a,b){for(var c=1;c<arguments.length;c++)var d=String(arguments[c]).replace(/\$/g,ga),a=a.replace(/\%s/,d);return a};var Bb=function(a,b){b.unshift(a);zb.call(this,Ab.apply(l,b));b.shift()};E(Bb,zb);var F=function(a,b,c){if(!a){var d=Array.prototype.slice.call(arguments,2),f=qa;if(b)var f=f+(oa+b),e=d;h(new Bb(r+f,e||[]))}return a};var G=Array.prototype,H=G.indexOf?function(a,b,c){F(a.length!=l);return G.indexOf.call(a,b,c)}:function(a,b,c){c=c==l?0:0>c?Math.max(0,a.length+c):c;if(A(a))return!A(b)||1!=b.length?-1:a.indexOf(b,c);for(;c<a.length;c++)if(c in a&&a[c]===b)return c;return-1},Cb=G.forEach?function(a,b,c){F(a.length!=l);G.forEach.call(a,b,c)}:function(a,b,c){for(var d=a.length,f=A(a)?a.split(r):a,e=0;e<d;e++)e in f&&b.call(c,f[e],e,a)},Db=G.filter?function(a,b,c){F(a.length!=l);return G.filter.call(a,b,c)}:function(a,
b,c){for(var d=a.length,f=[],e=0,g=A(a)?a.split(r):a,j=0;j<d;j++)if(j in g){var n=g[j];b.call(c,n,j,a)&&(f[e++]=n)}return f},Eb=function(a,b){var c=H(a,b),d;if(d=0<=c)F(a.length!=l),G.splice.call(a,c,1);return d},Fb=function(a,b,c){F(a.length!=l);return 2>=arguments.length?G.slice.call(a,b):G.slice.call(a,b,c)};var Gb=function(a){var b=[],c=0,d;for(d in a)b[c++]=a[d];return b},Hb=function(a){var b=[],c=0,d;for(d in a)b[c++]=d;return b},Ib="constructor hasOwnProperty isPrototypeOf propertyIsEnumerable toLocaleString toString valueOf".split(" "),Jb=function(a,b){for(var c,d,f=1;f<arguments.length;f++){d=arguments[f];for(c in d)a[c]=d[c];for(var e=0;e<Ib.length;e++)c=Ib[e],Object.prototype.hasOwnProperty.call(d,c)&&(a[c]=d[c])}};var I,Kb,Lb,Mb,Nb=function(){return x.navigator?x.navigator.userAgent:l};Mb=Lb=Kb=I=m;var Ob;if(Ob=Nb()){var Pb=x.navigator;I=0==Ob.indexOf("Opera");Kb=!I&&-1!=Ob.indexOf("MSIE");Lb=!I&&-1!=Ob.indexOf("WebKit");Mb=!I&&!Lb&&"Gecko"==Pb.product}var Qb=I,J=Kb,K=Mb,L=Lb,Rb;
a:{var Sb=r,M;if(Qb&&x.opera)var Tb=x.opera.version,Sb=typeof Tb==v?Tb():Tb;else if(K?M=/rv\:([^\);]+)(\)|;)/:J?M=/MSIE\s+([^\);]+)(\)|;)/:L&&(M=/WebKit\/(\S+)/),M)var Ub=M.exec(Nb()),Sb=Ub?Ub[1]:r;if(J){var Vb,Wb=x.document;Vb=Wb?Wb.documentMode:i;if(Vb>parseFloat(Sb)){Rb=String(Vb);break a}}Rb=Sb}
var Xb=Rb,Yb={},N=function(a){var b;if(!(b=Yb[a])){b=0;for(var c=String(Xb).replace(/^[\s\xa0]+|[\s\xa0]+$/g,r).split(la),d=String(a).replace(/^[\s\xa0]+|[\s\xa0]+$/g,r).split(la),f=Math.max(c.length,d.length),e=0;0==b&&e<f;e++){var g=c[e]||r,j=d[e]||r,n=RegExp(ia,Ma),q=RegExp(ia,Ma);do{var t=n.exec(g)||[r,r,r],p=q.exec(j)||[r,r,r];if(0==t[0].length&&0==p[0].length)break;b=((0==t[1].length?0:parseInt(t[1],10))<(0==p[1].length?0:parseInt(p[1],10))?-1:(0==t[1].length?0:parseInt(t[1],10))>(0==p[1].length?
0:parseInt(p[1],10))?1:0)||((0==t[2].length)<(0==p[2].length)?-1:(0==t[2].length)>(0==p[2].length)?1:0)||(t[2]<p[2]?-1:t[2]>p[2]?1:0)}while(0==b)}b=Yb[a]=0<=b}return b},Zb={},$b=function(a){return Zb[a]||(Zb[a]=J&&!!document.documentMode&&document.documentMode>=a)};var ac=function(a){ac[s](a);return a};ac[s]=tb;!J||$b(9);var bc=!J||$b(9),cc=J&&!N("9");!L||N("528");K&&N("1.9b")||J&&N("8")||Qb&&N("9.5")||L&&N("528");K&&!N("8")||J&&N("9");var dc=function(){};dc.prototype.disposed_=m;dc.prototype.dispose=function(){this.disposed_||(this.disposed_=k,this.disposeInternal())};dc.prototype.disposeInternal=function(){this.dependentDisposables_&&ec.apply(l,this.dependentDisposables_);if(this.onDisposeCallbacks_)for(;this.onDisposeCallbacks_.length;)this.onDisposeCallbacks_.shift()()};var ec=function(a){for(var b=0,c=arguments.length;b<c;++b){var d=arguments[b];z(d)?ec.apply(l,d):d&&typeof d.dispose==v&&d.dispose()}};var O=function(a,b){this.type=a;this.currentTarget=this.target=b};w=O.prototype;w.disposeInternal=function(){};w.dispose=function(){};w.propagationStopped_=m;w.defaultPrevented=m;w.returnValue_=k;w.preventDefault=function(){this.defaultPrevented=k;this.returnValue_=m};var P=function(a,b){a&&this.init(a,b)};E(P,O);w=P.prototype;w.target=l;w.relatedTarget=l;w.offsetX=0;w.offsetY=0;w.clientX=0;w.clientY=0;w.screenX=0;w.screenY=0;w.button=0;w.keyCode=0;w.charCode=0;w.ctrlKey=m;w.altKey=m;w.shiftKey=m;w.metaKey=m;w.event_=l;
w.init=function(a,b){var c=this.type=a.type;O.call(this,c);this.target=a.target||a.srcElement;this.currentTarget=b;var d=a.relatedTarget;if(d){if(K){var f;a:{try{ac(d.nodeName);f=k;break a}catch(e){}f=m}f||(d=l)}}else c==Ta?d=a.fromElement:c==Sa&&(d=a.toElement);this.relatedTarget=d;this.offsetX=L||a.offsetX!==i?a.offsetX:a.layerX;this.offsetY=L||a.offsetY!==i?a.offsetY:a.layerY;this.clientX=a.clientX!==i?a.clientX:a.pageX;this.clientY=a.clientY!==i?a.clientY:a.pageY;this.screenX=a.screenX||0;this.screenY=
a.screenY||0;this.button=a.button;this.keyCode=a.keyCode||0;this.charCode=a.charCode||(c==Ra?a.keyCode:0);this.ctrlKey=a.ctrlKey;this.altKey=a.altKey;this.shiftKey=a.shiftKey;this.metaKey=a.metaKey;this.state=a.state;this.event_=a;a.defaultPrevented&&this.preventDefault();delete this.propagationStopped_};
w.preventDefault=function(){P.superClass_.preventDefault.call(this);var a=this.event_;if(a.preventDefault)a.preventDefault();else if(a.returnValue=m,cc)try{if(a.ctrlKey||112<=a.keyCode&&123>=a.keyCode)a.keyCode=-1}catch(b){}};w.disposeInternal=function(){};var fc=function(){},gc=0;w=fc.prototype;w.key=0;w.removed=m;w.callOnce=m;w.init=function(a,b,c,d,f,e){y(a)==v?this.isFunctionListener_=k:a&&a.handleEvent&&y(a.handleEvent)==v?this.isFunctionListener_=m:h(Error("Invalid listener argument"));this.listener=a;this.proxy=b;this.src=c;this.type=d;this.capture=!!f;this.handler=e;this.callOnce=m;this.key=++gc;this.removed=m};
w.handleEvent=function(a){return this.isFunctionListener_?this.listener.call(this.handler||this.src,a):this.listener.handleEvent.call(this.listener,a)};var Q={},R={},S={},T={},U=function(a,b,c,d,f){if(b){if(y(b)==u){for(var e=0;e<b.length;e++)U(a,b[e],c,d,f);return l}var d=!!d,g=R;b in g||(g[b]={count_:0,remaining_:0});g=g[b];d in g||(g[d]={count_:0,remaining_:0},g.count_++);var g=g[d],j=B(a),n;g.remaining_++;if(g[j]){n=g[j];for(e=0;e<n.length;e++)if(g=n[e],g.listener==c&&g.handler==f){if(g.removed)break;return n[e].key}}else n=g[j]=[],g.count_++;var q=hc,t=bc?function(a){return q.call(t.src,t.key,a)}:function(a){a=q.call(t.src,t.key,a);if(!a)return a},
e=t;e.src=a;g=new fc;g.init(c,e,a,b,d,f);c=g.key;e.key=c;n.push(g);Q[c]=g;S[j]||(S[j]=[]);S[j].push(g);a.addEventListener?(a==x||!a.customEvent_)&&a.addEventListener(b,e,d):a.attachEvent(b in T?T[b]:T[b]=Ya+b,e);return c}h(Error("Invalid event type"))},ic=function(a,b,c,d,f){if(y(b)==u){for(var e=0;e<b.length;e++)ic(a,b[e],c,d,f);return l}a=U(a,b,c,d,f);Q[a].callOnce=k;return a},jc=function(a,b,c,d,f){if(y(b)==u){for(var e=0;e<b.length;e++)jc(a,b[e],c,d,f);return l}d=!!d;a:{e=R;if(b in e&&(e=e[b],
d in e&&(e=e[d],a=B(a),e[a]))){a=e[a];break a}a=l}if(!a)return m;for(e=0;e<a.length;e++)if(a[e].listener==c&&a[e].capture==d&&a[e].handler==f)return kc(a[e].key);return m},kc=function(a){if(!Q[a])return m;var b=Q[a];if(b.removed)return m;var c=b.src,d=b.type,f=b.proxy,e=b.capture;c.removeEventListener?(c==x||!c.customEvent_)&&c.removeEventListener(d,f,e):c.detachEvent&&c.detachEvent(d in T?T[d]:T[d]=Ya+d,f);c=B(c);S[c]&&(f=S[c],Eb(f,b),0==f.length&&delete S[c]);b.removed=k;if(b=R[d][e][c])b.needsCleanup_=
k,lc(d,e,c,b);delete Q[a];return k},lc=function(a,b,c,d){if(!d.locked_&&d.needsCleanup_){for(var f=0,e=0;f<d.length;f++)d[f].removed?d[f].proxy.src=l:(f!=e&&(d[e]=d[f]),e++);d.length=e;d.needsCleanup_=m;0==e&&(delete R[a][b][c],R[a][b].count_--,0==R[a][b].count_&&(delete R[a][b],R[a].count_--),0==R[a].count_&&delete R[a])}},mc=function(a,b,c){var d=0,f=b==l,e=c==l,c=!!c;if(a==l){var a=function(a){for(var g=a.length-1;0<=g;g--){var j=a[g];if((f||b==j.type)&&(e||c==j.capture))kc(j.key),d++}},g;for(g in S)a.call(i,
S[g],g,S)}else if(g=B(a),S[g]){g=S[g];for(a=g.length-1;0<=a;a--){var j=g[a];if((f||b==j.type)&&(e||c==j.capture))kc(j.key),d++}}return d},V=function(a,b,c,d,f){var e=1,b=B(b);if(a[b]){a.remaining_--;a=a[b];a.locked_?a.locked_++:a.locked_=1;try{for(var g=a.length,j=0;j<g;j++){var n=a[j];n&&!n.removed&&(e&=nc(n,f)!==m)}}finally{a.locked_--,lc(c,d,b,a)}}return Boolean(e)},nc=function(a,b){a.callOnce&&kc(a.key);return a.handleEvent(b)},hc=function(a,b){if(!Q[a])return k;var c=Q[a],d=c.type,f=R;if(!(d in
f))return k;var f=f[d],e,g;if(!bc){var j;if(!(j=b))a:{j=[pb,La];for(var n=x;e=j.shift();)if(n[e]!=l)n=n[e];else{j=l;break a}j=n}e=j;j=k in f;n=m in f;if(j){if(0>e.keyCode||e.returnValue!=i)return k;a:{var q=m;if(0==e.keyCode)try{e.keyCode=-1;break a}catch(t){q=k}if(q||e.returnValue==i)e.returnValue=k}}q=new P;q.init(e,this);e=k;try{if(j){for(var p=[],ma=q.currentTarget;ma;ma=ma.parentNode)p.push(ma);g=f[k];g.remaining_=g.count_;for(var D=p.length-1;!q.propagationStopped_&&0<=D&&g.remaining_;D--)q.currentTarget=
p[D],e&=V(g,p[D],d,k,q);if(n){g=f[m];g.remaining_=g.count_;for(D=0;!q.propagationStopped_&&D<p.length&&g.remaining_;D++)q.currentTarget=p[D],e&=V(g,p[D],d,m,q)}}else e=nc(c,q)}finally{p&&(p.length=0)}return e}d=new P(b,this);return e=nc(c,d)};var oc=function(){};E(oc,dc);w=oc.prototype;w.customEvent_=k;w.parentEventTarget_=l;w.addEventListener=function(a,b,c,d){U(this,a,b,c,d)};w.removeEventListener=function(a,b,c,d){jc(this,a,b,c,d)};
w.dispatchEvent=function(a){var b=a.type||a,c=R;if(b in c){if(A(a))a=new O(a,this);else if(a instanceof O)a.target=a.target||this;else{var d=a,a=new O(b,this);Jb(a,d)}var d=1,f,c=c[b],b=k in c,e;if(b){f=[];for(e=this;e;e=e.parentEventTarget_)f.push(e);e=c[k];e.remaining_=e.count_;for(var g=f.length-1;!a.propagationStopped_&&0<=g&&e.remaining_;g--)a.currentTarget=f[g],d&=V(e,f[g],a.type,k,a)&&a.returnValue_!=m}if(m in c)if(e=c[m],e.remaining_=e.count_,b)for(g=0;!a.propagationStopped_&&g<f.length&&
e.remaining_;g++)a.currentTarget=f[g],d&=V(e,f[g],a.type,m,a)&&a.returnValue_!=m;else for(f=this;!a.propagationStopped_&&f&&e.remaining_;f=f.parentEventTarget_)a.currentTarget=f,d&=V(e,f,a.type,m,a)&&a.returnValue_!=m;a=Boolean(d)}else a=k;return a};w.disposeInternal=function(){oc.superClass_.disposeInternal.call(this);mc(this);this.parentEventTarget_=l};var pc=function(a,b){b.preventDefault();a(b);return m};var qc=function(a){a=a.className;return A(a)&&a.match(/\S+/g)||[]},rc=function(a,b){for(var c=qc(a),d=Fb(arguments,1),f=c.length+d.length,e=c,g=0;g<d.length;g++)0<=H(e,d[g])||e.push(d[g]);a.className=c.join(s);return c.length==f},sc=function(a,b){var c=qc(a),d=Fb(arguments,1),f,e=d;f=Db(c,function(a){return!(0<=H(e,a))});a.className=f.join(s);return f.length==c.length-d.length},tc=function(a,b){var c=qc(a);(c=!(0<=H(c,b)))?rc(a,b):sc(a,b);return c};!J||$b(9);!K&&!J||J&&$b(9)||K&&N("1.9.1");var uc=J&&!N("9");var vc=function(a,b,c,d){a=d||a;b=b&&b!=ka?b.toUpperCase():r;if(a.querySelectorAll&&a.querySelector&&(b||c))return a.querySelectorAll(b+(c?la+c:r));if(c&&a.getElementsByClassName){a=a.getElementsByClassName(c);if(b){for(var d={},f=0,e=0,g;g=a[e];e++)b==g.nodeName&&(d[f++]=g);d.length=f;return d}return a}a=a.getElementsByTagName(b||ka);if(c){d={};for(e=f=0;g=a[e];e++)b=g.className,typeof b.split==v&&0<=H(b.split(/\s+/),c)&&(d[f++]=g);d.length=f;return d}return a},wc={SCRIPT:1,STYLE:1,HEAD:1,IFRAME:1,
OBJECT:1},xc={IMG:s,BR:aa},zc=function(a){if(uc&&Qa in a)a=a.innerText.replace(/(\r\n|\r|\n)/g,aa);else{var b=[];yc(a,b,k);a=b.join(r)}a=a.replace(/ \xAD /g,s).replace(/\xAD/g,r);a=a.replace(/\u200B/g,r);uc||(a=a.replace(/ +/g,s));a!=s&&(a=a.replace(/^\s*/,r));return a},yc=function(a,b,c){if(!(a.nodeName in wc))if(3==a.nodeType)c?b.push(String(a.nodeValue).replace(/(\r\n|\r|\n)/g,r)):b.push(a.nodeValue);else if(a.nodeName in xc)b.push(xc[a.nodeName]);else for(a=a.firstChild;a;)yc(a,b,c),a=a.nextSibling};var W="StopIteration"in x?x.StopIteration:Error("StopIteration"),X=function(){};X.prototype.next=function(){h(W)};X.prototype.__iterator__=function(){return this};var Ac=function(a){if(a instanceof X)return a;if(typeof a.__iterator__==v)return a.__iterator__(m);if(z(a)){var b=0,c=new X;c.next=function(){for(;;){b>=a.length&&h(W);if(b in a)return a[b++];b++}};return c}h(Error("Not implemented"))};var Bc=function(a){if(typeof a.getValues==v)return a.getValues();if(A(a))return a.split(r);if(z(a)){for(var b=[],c=a.length,d=0;d<c;d++)b.push(a[d]);return b}return Gb(a)},Cc=function(a,b,c){if(typeof a.forEach==v)a.forEach(b,c);else if(z(a)||A(a))Cb(a,b,c);else{var d;if(typeof a.getKeys==v)d=a.getKeys();else if(typeof a.getValues!=v)if(z(a)||A(a)){d=[];for(var f=a.length,e=0;e<f;e++)d.push(e)}else d=Hb(a);else d=i;for(var f=Bc(a),e=f.length,g=0;g<e;g++)b.call(c,f[g],d&&d[g],a)}};var Y=function(a,b){this.map_={};this.keys_=[];var c=arguments.length;if(1<c){c%2&&h(Error("Uneven number of arguments"));for(var d=0;d<c;d+=2)this.set(arguments[d],arguments[d+1])}else a&&this.addAll(a)};w=Y.prototype;w.count_=0;w.version_=0;w.getValues=function(){this.cleanupKeysArray_();for(var a=[],b=0;b<this.keys_.length;b++)a.push(this.map_[this.keys_[b]]);return a};w.getKeys=function(){this.cleanupKeysArray_();return this.keys_.concat()};w.containsKey=function(a){return Z(this.map_,a)};
w.remove=function(a){return Z(this.map_,a)?(delete this.map_[a],this.count_--,this.version_++,this.keys_.length>2*this.count_&&this.cleanupKeysArray_(),k):m};w.cleanupKeysArray_=function(){if(this.count_!=this.keys_.length){for(var a=0,b=0;a<this.keys_.length;){var c=this.keys_[a];Z(this.map_,c)&&(this.keys_[b++]=c);a++}this.keys_.length=b}if(this.count_!=this.keys_.length){for(var d={},b=a=0;a<this.keys_.length;)c=this.keys_[a],Z(d,c)||(this.keys_[b++]=c,d[c]=1),a++;this.keys_.length=b}};
w.get=function(a,b){return Z(this.map_,a)?this.map_[a]:b};w.set=function(a,b){Z(this.map_,a)||(this.count_++,this.keys_.push(a),this.version_++);this.map_[a]=b};w.addAll=function(a){var b;a instanceof Y?(b=a.getKeys(),a=a.getValues()):(b=Hb(a),a=Gb(a));for(var c=0;c<b.length;c++)this.set(b[c],a[c])};w.clone=function(){return new Y(this)};w.getKeyIterator=function(){return this.__iterator__(k)};
w.__iterator__=function(a){this.cleanupKeysArray_();var b=0,c=this.keys_,d=this.map_,f=this.version_,e=this,g=new X;g.next=function(){for(;;){f!=e.version_&&h(Error("The map has changed since the iterator was created"));b>=c.length&&h(W);var g=c[b++];return a?g:d[g]}};return g};var Z=function(a,b){return Object.prototype.hasOwnProperty.call(a,b)};var Dc=function(a){a=String(a);if(/^\s*$/.test(a)?0:/^[\],:{}\s\u2028\u2029]*$/.test(a.replace(/\\["\\\/bfnrtu]/g,pa).replace(/"[^"\\\n\r\u2028\u2029\x00-\x08\x0a-\x1f]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,Ba).replace(/(?:^|:|,)(?:[\s\u2028\u2029]*\[)+/g,r)))try{return eval(ha+a+ja)}catch(b){}h(Error("Invalid JSON string: "+a))};var Ec=x.window;var Fc=RegExp("^(?:([^:/?#.]+):)?(?://(?:([^/?#]*)@)?([\\w\\d\\-\\u0100-\\uffff.%]*)(?::([0-9]+))?)?([^?#]+)?(?:\\?([^#]*))?(?:#(.*))?$"),Gc=L,Hc=function(a,b){if(Gc){Gc=m;var c=x.location;if(c){var d=c.href;if(d&&(d=(d=Hc(3,d))&&decodeURIComponent(d))&&d!=c.hostname)Gc=k,h(Error())}}return b.match(Fc)[a]||l};var Ic=function(){};Ic.prototype.cachedOptions_=l;Ic.prototype.getOptions=function(){return this.cachedOptions_||(this.cachedOptions_=this.internalGetOptions())};var Jc,$=function(){};E($,Ic);$.prototype.createInstance=function(){var a=this.getProgId_();return a?new ActiveXObject(a):new XMLHttpRequest};$.prototype.internalGetOptions=function(){var a={};this.getProgId_()&&(a[0]=k,a[1]=k);return a};$.prototype.getProgId_=function(){if(!this.ieProgId_&&"undefined"==typeof XMLHttpRequest&&"undefined"!=typeof ActiveXObject){for(var a=[va,ua,ta,wa],b=0;b<a.length;b++){var c=a[b];try{return new ActiveXObject(c),this.ieProgId_=c}catch(d){}}h(Error("Could not create ActiveXObject. ActiveX might be disabled, or MSXML might not be installed"))}return this.ieProgId_};
Jc=new $;var Kc=function(a){this.headers=new Y;this.xmlHttpFactory_=a||l};E(Kc,oc);var Lc=/^https?$/i,Mc=[],Oc=function(a,b,c,d,f,e,g){var j=new Kc;Mc.push(j);b&&U(j,Ja,b);U(j,Za,yb(Nc,j));e&&j.setTimeoutInterval(e);g&&j.setWithCredentials(g);j.send(a,c,d,f)},Nc=function(a){a.dispose();Eb(Mc,a)};w=Kc.prototype;w.active_=m;w.xhr_=l;w.xhrOptions_=l;w.lastUri_=r;w.errorDispatched_=m;w.inSend_=m;w.inOpen_=m;w.inAbort_=m;w.timeoutInterval_=0;w.timeoutId_=l;w.responseType_=r;w.withCredentials_=m;
w.setTimeoutInterval=function(a){this.timeoutInterval_=Math.max(0,a)};w.setWithCredentials=function(a){this.withCredentials_=a};
w.send=function(a,b,c,d){this.xhr_&&h(Error("[goog.net.XhrIo] Object is active with another request="+this.lastUri_+"; newUri="+a));b=b?b.toUpperCase():sa;this.lastUri_=a;this.errorDispatched_=m;this.active_=k;this.xhr_=this.createXhr();this.xhrOptions_=this.xmlHttpFactory_?this.xmlHttpFactory_.getOptions():Jc.getOptions();this.xhr_.onreadystatechange=C(this.onReadyStateChange_,this);try{this.inOpen_=k,this.xhr_.open(b,a,k),this.inOpen_=m}catch(f){this.error_(5,f);return}var a=c||r,e=this.headers.clone();
d&&Cc(d,function(a,b){e.set(b,a)});d=x.FormData&&a instanceof x.FormData;b==xa&&(!e.containsKey(ra)&&!d)&&e.set(ra,Ga);Cc(e,function(a,b){this.xhr_.setRequestHeader(b,a)},this);this.responseType_&&(this.xhr_.responseType=this.responseType_);qb in this.xhr_&&(this.xhr_.withCredentials=this.withCredentials_);try{this.timeoutId_&&(Ec.clearTimeout(this.timeoutId_),this.timeoutId_=l),0<this.timeoutInterval_&&(this.timeoutId_=Ec.setTimeout(C(this.timeout_,this),this.timeoutInterval_)),this.inSend_=k,this.xhr_.send(a),
this.inSend_=m}catch(g){this.error_(5,g)}};w.createXhr=function(){return this.xmlHttpFactory_?this.xmlHttpFactory_.createInstance():Jc.createInstance()};w.timeout_=function(){"undefined"!=typeof rb&&this.xhr_&&(this.dispatchEvent(nb),this.abort(8))};w.error_=function(){this.active_=m;this.xhr_&&(this.inAbort_=k,this.xhr_.abort(),this.inAbort_=m);this.dispatchErrors_();this.cleanUpXhr_()};w.dispatchErrors_=function(){this.errorDispatched_||(this.errorDispatched_=k,this.dispatchEvent(Ja),this.dispatchEvent(Ka))};
w.abort=function(){this.xhr_&&this.active_&&(this.active_=m,this.inAbort_=k,this.xhr_.abort(),this.inAbort_=m,this.dispatchEvent(Ja),this.dispatchEvent(Fa),this.cleanUpXhr_())};w.disposeInternal=function(){this.xhr_&&(this.active_&&(this.active_=m,this.inAbort_=k,this.xhr_.abort(),this.inAbort_=m),this.cleanUpXhr_(k));Kc.superClass_.disposeInternal.call(this)};w.onReadyStateChange_=function(){if(!this.inOpen_&&!this.inSend_&&!this.inAbort_)this.onReadyStateChangeEntryPoint_();else this.onReadyStateChangeHelper_()};
w.onReadyStateChangeEntryPoint_=function(){this.onReadyStateChangeHelper_()};w.onReadyStateChangeHelper_=function(){if(this.active_&&"undefined"!=typeof rb&&(!this.xhrOptions_[1]||!(4==this.getReadyState()&&2==this.getStatus())))if(this.inSend_&&4==this.getReadyState())Ec.setTimeout(C(this.onReadyStateChange_,this),0);else if(this.dispatchEvent($a),this.isComplete()){this.active_=m;try{this.isSuccess()?(this.dispatchEvent(Ja),this.dispatchEvent(mb)):this.dispatchErrors_()}finally{this.cleanUpXhr_()}}};
w.cleanUpXhr_=function(a){if(this.xhr_){var b=this.xhr_,c=this.xhrOptions_[0]?tb:l;this.xhrOptions_=this.xhr_=l;this.timeoutId_&&(Ec.clearTimeout(this.timeoutId_),this.timeoutId_=l);a||this.dispatchEvent(Za);try{b.onreadystatechange=c}catch(d){}}};w.isComplete=function(){return 4==this.getReadyState()};w.isSuccess=function(){var a=this.getStatus(),b;a:switch(a){case 200:case 201:case 202:case 204:case 206:case 304:case 1223:b=k;break a;default:b=m}return b||0===a&&!this.isLastUriEffectiveSchemeHttp_()};
w.isLastUriEffectiveSchemeHttp_=function(){var a=Hc(1,String(this.lastUri_));!a&&self.location&&(a=self.location.protocol,a=a.substr(0,a.length-1));return Lc.test(a?a.toLowerCase():r)};w.getReadyState=function(){return this.xhr_?this.xhr_.readyState:0};w.getStatus=function(){try{return 2<this.getReadyState()?this.xhr_.status:-1}catch(a){return-1}};w.getResponseJson=function(a){if(this.xhr_){var b=this.xhr_.responseText;a&&0==b.indexOf(a)&&(b=b.substring(a.length));return Dc(b)}};var Pc=function(a,b){this.entityId_=encodeURIComponent(a);b?this.sender_=b:(this.sender_=Kc,this.sender_.send=Oc);this.writeToken_=r;this.options_={};this.counts_={};this.decodeLabel_={};this.selectedReactions_=new Y};w=Pc.prototype;
w.initialize=function(a){for(var a=vc(document,Ea,hb,document.getElementById(a)),b=0;b<a.length;b++){var c=a[b],d=vc(document,jb,gb,c)[0],d=zc(d);this.options_[d]=c;var f=this.encodeLabel_(d);this.decodeLabel_[f]=d;var f=c,e=C(this.toggle,this,d);U(f,Ia,pc.partial(e));c=vc(document,jb,eb,c)[0];this.counts_[d]=c;c.innerHTML=na}a=C(this.displayRetrievedAnnotations_,this);b=C(this.disableOptions_,this);this.loadExistingReactions_(a,b)};w.setZipitToken_=function(a){this.writeToken_=a};
w.loadZipitToken_=function(a){var b=C(this.disableOptions_,this),c=C(this.setZipitToken_,this),d=C(this.toggle,this);this.sender_.send(Oa,function(){if(this.isSuccess()){var f=this.getResponseJson();c(f.channelHeader.token);a&&d(a)}else b()},xa,bb)};w.loadExistingReactions_=function(a,b){this.sender_.send(Na,function(){this.isSuccess()?a(this.getResponseJson()):b()},xa,cb+this.entityId_+ea+this.entityId_+fa)};
w.displayRetrievedAnnotations_=function(a){if(a.entityAggregates)for(var b=0;b<a.entityAggregates.length;b++){var c=m;if(c=a.entityAggregates[b].labels)for(var d=0;d<c.length;d++){var f=this.counts_[this.decodeLabel_[c[d].label]];if(f){var e=parseInt(zc(f),10);isNaN(e)&&(e=0);f.innerHTML=e+parseInt(c[d].count,10)}}}};w.encodeLabel_=function(a){a=a.replace(/([^A-Za-z ])/g,function(a){return Da+a.charCodeAt(0)});return a=a.replace(/([A-Z])/g,function(a){return Da+a.toLowerCase()})};
w.disableOptions_=function(){for(var a=vc(document,Ea,hb,document.getElementById(fb)),b=0;b<a.length;b++){var c=a[b];c.style.borderColor=l;mc(c)}};
w.toggle=function(a){if(this.writeToken_==r)this.loadZipitToken_(a);else{if(this.selectedReactions_.get(a)){var b=m;this.selectedReactions_.remove(a)}else b=k,this.selectedReactions_.set(a,k);var c=r,d=this.selectedReactions_.getKeyIterator(),f=function(a){c=c+ba+this.encodeLabel_(a)+ca};if(z(d))try{Cb(d,f,this)}catch(e){e!==W&&h(e)}else{d=Ac(d);try{for(;;)f.call(this,d.next(),i,d)}catch(g){g!==W&&h(g)}}this.sender_.send(Pa,tb,xa,ab+this.entityId_+da+c+Ca+this.writeToken_);if(d=this.options_[a])a=
this.counts_[a],f=parseInt(zc(a),10),isNaN(f)&&(f=0),a.innerHTML=b?f+1:f-1,tc(d,db),tc(d,ib)}};sb("BLOG_Annotator",Pc,i);Pc.prototype.initialize=Pc.prototype.initialize;sb("BLOG_listenOnce",ic,i); })()
