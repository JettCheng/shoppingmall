(window.webpackJsonp=window.webpackJsonp||[]).push([[5],{"8y03":function(e,t,r){"use strict";r.r(t),r.d(t,"CheckoutModule",function(){return A});var c=r("SVse"),o=r("PCNd"),i=r("iInd"),n=r("8Y7J");function s(e,t){if(1&e&&(n.Vb(0,"button",5),n.Gc(1,"\u67e5\u770b\u6b64\u8a02\u55ae"),n.Ub()),2&e){const e=n.ec();n.oc("routerLink","/orders/",null==e.order?null:e.order.id,"")}}function a(e,t){1&e&&(n.Vb(0,"button",6),n.Gc(1,"\u6240\u6709\u8a02\u55ae"),n.Ub())}let b=(()=>{class e{constructor(e){this.router=e;const t=this.router.getCurrentNavigation(),r=t&&t.extras&&t.extras.state;r&&(this.order=r)}ngOnInit(){}}return e.\u0275fac=function(t){return new(t||e)(n.Pb(i.c))},e.\u0275cmp=n.Jb({type:e,selectors:[["app-checkout-success"]],decls:9,vars:2,consts:[[1,"container","mt-5"],[1,"fa","fa-check-circle","fa-5x",2,"color","green"],[1,"mb-4"],["class","btn btn-outline-success",3,"routerLink",4,"ngIf"],["routerLink","/orders","class","btn btn-outline-success",4,"ngIf"],[1,"btn","btn-outline-success",3,"routerLink"],["routerLink","/orders",1,"btn","btn-outline-success"]],template:function(e,t){1&e&&(n.Vb(0,"div",0),n.Vb(1,"div"),n.Qb(2,"i",1),n.Ub(),n.Vb(3,"h2"),n.Gc(4,"\u60a8\u7684\u8a02\u55ae\u5df2\u5efa\u7acb\u6210\u529f\uff0c\u8b1d\u8b1d\uff01"),n.Ub(),n.Vb(5,"p",2),n.Gc(6,"\u60a8\u7684\u8ca8\u7269\u7121\u6cd5\u9001\u9054\uff0c\u56e0\u70ba\u9019\u4e0d\u662f\u771f\u7684\u5546\u5e97\u5537"),n.Ub(),n.Ec(7,s,2,1,"button",3),n.Ec(8,a,2,0,"button",4),n.Ub()),2&e&&(n.Cb(7),n.mc("ngIf",t.order),n.Cb(1),n.mc("ngIf",!t.order))},directives:[c.m,i.d],styles:[""]}),e})();var l=r("s7LF"),u=r("2rwd"),d=r("cAP4"),p=r("9PhW"),m=r("q59W"),f=r("EApP"),h=r("gA0Q");let v=(()=>{class e{constructor(e,t){this.accountService=e,this.toastr=t}ngOnInit(){}saveUserAddress(){this.accountService.updateUserAddress(this.checkoutForm.get("addressForm").value).subscribe(e=>{this.toastr.success("\u5730\u5740\u5df2\u5132\u5b58"),this.checkoutForm.get("addressForm").reset(e)},e=>{this.toastr.error("\u5efa\u7acb\u5931\u6557\uff0c\u60a8\u6709\u5fc5\u586b\u8cc7\u6599\u5c1a\u672a\u586b\u5beb"),console.log(e)})}}return e.\u0275fac=function(t){return new(t||e)(n.Pb(u.a),n.Pb(f.b))},e.\u0275cmp=n.Jb({type:e,selectors:[["app-checkout-address"]],inputs:{checkoutForm:"checkoutForm"},decls:26,vars:9,consts:[[1,"mt-4",3,"formGroup"],[1,"d-flex","justify-content-between","align-items-center"],[1,"btn","btn-outline-success","mb-3",3,"disabled","click"],["formGroupName","addressForm",1,"row"],[1,"form-group","col-6"],["formControlName","firstName",3,"label"],["formControlName","lastName",3,"label"],["formControlName","street",3,"label"],["formControlName","city",3,"label"],["formControlName","state",3,"label"],["formControlName","zipCode",3,"label"],[1,"float-none","d-flex","justify-content-between","flex-column","flex-lg-row","mb-5"],["routerLink","/basket",1,"btn","btn-outline-primary"],[1,"fa","fa-angle-left"],["cdkStepperNext","",1,"btn","btn-primary",3,"disabled"],[1,"fa","fa-angle-right"]],template:function(e,t){1&e&&(n.Vb(0,"div",0),n.Vb(1,"div",1),n.Vb(2,"h4"),n.Gc(3,"\u5230\u8ca8\u5730\u5740"),n.Ub(),n.Vb(4,"button",2),n.cc("click",function(){return t.saveUserAddress()}),n.Gc(5,"\u8a2d\u5b9a\u70ba\u9810\u8a2d\u5730\u5740"),n.Ub(),n.Ub(),n.Vb(6,"div",3),n.Vb(7,"div",4),n.Qb(8,"app-text-input",5),n.Ub(),n.Vb(9,"div",4),n.Qb(10,"app-text-input",6),n.Ub(),n.Vb(11,"div",4),n.Qb(12,"app-text-input",7),n.Ub(),n.Vb(13,"div",4),n.Qb(14,"app-text-input",8),n.Ub(),n.Vb(15,"div",4),n.Qb(16,"app-text-input",9),n.Ub(),n.Vb(17,"div",4),n.Qb(18,"app-text-input",10),n.Ub(),n.Ub(),n.Ub(),n.Vb(19,"div",11),n.Vb(20,"button",12),n.Qb(21,"i",13),n.Gc(22," \u56de\u5230\u8cfc\u7269\u8eca "),n.Ub(),n.Vb(23,"button",14),n.Gc(24," \u4e0b\u4e00\u6b65 "),n.Qb(25,"i",15),n.Ub(),n.Ub()),2&e&&(n.mc("formGroup",t.checkoutForm),n.Cb(4),n.mc("disabled",!t.checkoutForm.get("addressForm").valid||!t.checkoutForm.get("addressForm").dirty),n.Cb(4),n.mc("label","\u59d3\u6c0f"),n.Cb(2),n.mc("label","\u540d\u5b57"),n.Cb(2),n.mc("label","\u7e23\u5e02"),n.Cb(2),n.mc("label","\u5340"),n.Cb(2),n.mc("label","\u5730\u5740"),n.Cb(2),n.mc("label","\u90f5\u905e\u5340\u865f"),n.Cb(5),n.mc("disabled",t.checkoutForm.get("addressForm").invalid))},directives:[l.l,l.f,l.g,h.a,l.k,l.d,i.d,m.d],styles:[""]}),e})();var g=r("lJxs"),k=r("AytR"),y=r("IheW");let V=(()=>{class e{constructor(e){this.http=e,this.baseUrl=k.a.apiUrl}createOrder(e){return this.http.post(this.baseUrl+"orders",e)}getDeliveryMethods(){return this.http.get(this.baseUrl+"orders/deliveryMethods").pipe(Object(g.a)(e=>e.data.sort((e,t)=>t.price-e.price)))}}return e.\u0275fac=function(t){return new(t||e)(n.Zb(y.b))},e.\u0275prov=n.Lb({token:e,factory:e.\u0275fac,providedIn:"root"}),e})();function U(e,t){if(1&e){const e=n.Wb();n.Vb(0,"div",9),n.Vb(1,"input",10),n.cc("click",function(){n.yc(e);const r=t.$implicit;return n.ec().setShippingPrice(r)}),n.Ub(),n.Vb(2,"label",11),n.Vb(3,"strong"),n.Gc(4),n.fc(5,"currency"),n.Ub(),n.Qb(6,"br"),n.Vb(7,"span",12),n.Gc(8),n.Ub(),n.Ub(),n.Ub()}if(2&e){const e=t.$implicit;n.Cb(1),n.nc("id",e.id),n.nc("value",e.id),n.Cb(1),n.nc("for",e.id),n.Cb(2),n.Jc("",e.shortName," - ",n.jc(5,6,e.price,"TWD",!0,"1.0-0"),""),n.Cb(4),n.Hc(e.description)}}let C=(()=>{class e{constructor(e,t){this.checkoutService=e,this.basketService=t}ngOnInit(){this.checkoutService.getDeliveryMethods().subscribe(e=>{this.deliveryMethods=e},e=>{console.log(e)})}setShippingPrice(e){this.basketService.setShippingPrice(e)}}return e.\u0275fac=function(t){return new(t||e)(n.Pb(V),n.Pb(d.a))},e.\u0275cmp=n.Jb({type:e,selectors:[["app-checkout-delivery"]],inputs:{checkoutForm:"checkoutForm"},decls:12,vars:3,consts:[[1,"mt-4",3,"formGroup"],[1,"mb-3"],["formGroupName","deliveryForm",1,"row"],["class","col-6 form-group",4,"ngFor","ngForOf"],[1,"float-none","d-flex","justify-content-between","flex-column","flex-lg-row","mb-5"],["cdkStepperPrevious","",1,"btn","btn-outline-primary"],[1,"fa","fa-angle-left"],["cdkStepperNext","",1,"btn","btn-primary",3,"disabled"],[1,"fa","fa-angle-right"],[1,"col-6","form-group"],["type","radio","formControlName","deliveryMethod",1,"custom-control-input",3,"id","value","click"],[1,"custom-control-label",3,"for"],[1,"label-description"]],template:function(e,t){1&e&&(n.Vb(0,"div",0),n.Vb(1,"h4",1),n.Gc(2,"\u8acb\u9078\u64c7\u60a8\u60f3\u8981\u7684\u5230\u8ca8\u65b9\u5f0f"),n.Ub(),n.Vb(3,"div",2),n.Ec(4,U,9,11,"div",3),n.Ub(),n.Ub(),n.Vb(5,"div",4),n.Vb(6,"button",5),n.Qb(7,"i",6),n.Gc(8," \u4e0a\u4e00\u6b65 "),n.Ub(),n.Vb(9,"button",7),n.Gc(10," \u4e0b\u4e00\u6b65 "),n.Qb(11,"i",8),n.Ub(),n.Ub()),2&e&&(n.mc("formGroup",t.checkoutForm),n.Cb(4),n.mc("ngForOf",t.deliveryMethods),n.Cb(5),n.mc("disabled",t.checkoutForm.get("deliveryForm").invalid))},directives:[l.l,l.f,l.g,c.l,m.e,m.d,l.n,l.a,l.k,l.d],pipes:[c.d],styles:[""]}),e})();var F=r("GJcC");let S=(()=>{class e{constructor(e,t){this.basketService=e,this.toastr=t}ngOnInit(){this.basket$=this.basketService.basket$}createPaymentIntent(){this.appStepper.next()}}return e.\u0275fac=function(t){return new(t||e)(n.Pb(d.a),n.Pb(f.b))},e.\u0275cmp=n.Jb({type:e,selectors:[["app-checkout-review"]],inputs:{appStepper:"appStepper"},decls:10,vars:4,consts:[[1,"mt-4"],[3,"isBasket","items"],[1,"float-none","d-flex","justify-content-between","flex-column","flex-lg-row","mb-5"],["cdkStepperPrevious","",1,"btn","btn-outline-primary"],[1,"fa","fa-angle-left"],[1,"btn","btn-primary",3,"click"],[1,"fa","fa-angle-right"]],template:function(e,t){1&e&&(n.Vb(0,"div",0),n.Qb(1,"app-basket-summary",1),n.fc(2,"async"),n.Ub(),n.Vb(3,"div",2),n.Vb(4,"button",3),n.Qb(5,"i",4),n.Gc(6," \u4e0a\u4e00\u6b65 "),n.Ub(),n.Vb(7,"button",5),n.cc("click",function(){return t.createPaymentIntent()}),n.Gc(8," \u4e0b\u4e00\u6b65 "),n.Qb(9,"i",6),n.Ub(),n.Ub()),2&e&&(n.Cb(1),n.mc("isBasket",!1)("items",n.gc(2,2,t.basket$).items))},directives:[F.a,m.e],pipes:[c.b],styles:[""]}),e})();var w=r("mrSG");const P=["cardNumber"],x=["cardExpiry"],G=["cardCvc"];function Q(e,t){1&e&&n.Qb(0,"i",11)}let N=(()=>{class e{constructor(e,t,r,c){this.basketService=e,this.checkoutService=t,this.toastr=r,this.router=c,this.loading=!1}ngAfterViewInit(){}ngOnDestroy(){}onChange(e){}submitOrder(){return Object(w.a)(this,void 0,void 0,function*(){this.loading=!0;const e=this.basketService.getCurrentBasketValue();try{const t=yield this.createOrder(e);yield this.confirmPaymentWithStripe(e),this.basketService.deleteLocalBasket(e.id),this.router.navigate(["checkout/success"],{state:t}),this.loading=!1}catch(t){console.log(t),this.loading=!1}})}confirmPaymentWithStripe(e){return Object(w.a)(this,void 0,void 0,function*(){})}createOrder(e){return Object(w.a)(this,void 0,void 0,function*(){const t=this.getOrderToCreate(e);return console.log("orderToCreate"),console.log(t),this.checkoutService.createOrder(t).toPromise()})}getOrderToCreate(e){return{basketId:e.id,deliveryMethodId:+this.checkoutForm.get("deliveryForm").get("deliveryMethod").value,shipToAddress:this.checkoutForm.get("addressForm").value}}}return e.\u0275fac=function(t){return new(t||e)(n.Pb(d.a),n.Pb(V),n.Pb(f.b),n.Pb(i.c))},e.\u0275cmp=n.Jb({type:e,selectors:[["app-checkout-payment"]],viewQuery:function(e,t){if(1&e&&(n.Kc(P,3),n.Kc(x,3),n.Kc(G,3)),2&e){let e;n.vc(e=n.dc())&&(t.cardNumberElement=e.first),n.vc(e=n.dc())&&(t.cardExpiryElement=e.first),n.vc(e=n.dc())&&(t.cardCvcElement=e.first)}},inputs:{checkoutForm:"checkoutForm"},decls:14,vars:4,consts:[[1,"mt-4",3,"formGroup"],[1,"row"],["formGroupName","paymentForm",1,"form-group","col-12"],["formControlName","nameOnCard",3,"label"],[1,"col-12","mb-2"],[1,"float-none","d-flex","justify-content-between","flex-column","flex-lg-row","mb-5"],["cdkStepperPrevious","",1,"btn","btn-outline-primary"],[1,"fa","fa-angle-left"],[1,"btn","btn-primary",3,"disabled","click"],[1,"fa","fa-angle-right"],["class","fa fa-spinner fa-spin",4,"ngIf"],[1,"fa","fa-spinner","fa-spin"]],template:function(e,t){1&e&&(n.Vb(0,"div",0),n.Vb(1,"div",1),n.Vb(2,"div",2),n.Qb(3,"app-text-input",3),n.Ub(),n.Vb(4,"div",4),n.Gc(5,"\u4fe1\u7528\u5361\u5361\u865f"),n.Ub(),n.Ub(),n.Ub(),n.Vb(6,"div",5),n.Vb(7,"button",6),n.Qb(8,"i",7),n.Gc(9," \u4e0a\u4e00\u6b65 "),n.Ub(),n.Vb(10,"button",8),n.cc("click",function(){return t.submitOrder()}),n.Gc(11," \u78ba\u8a8d\u9001\u51fa "),n.Qb(12,"i",9),n.Ec(13,Q,1,0,"i",10),n.Ub(),n.Ub()),2&e&&(n.mc("formGroup",t.checkoutForm),n.Cb(3),n.mc("label","\u540d\u5b57"),n.Cb(7),n.mc("disabled",t.loading||t.checkoutForm.get("paymentForm").invalid),n.Cb(3),n.mc("ngIf",t.loading))},directives:[l.l,l.f,l.g,h.a,l.k,l.d,m.e,c.m],styles:[""]}),e})();var I=r("PoZw");function O(e,t){if(1&e&&(n.Qb(0,"app-order-totals",11),n.fc(1,"async"),n.fc(2,"async"),n.fc(3,"async")),2&e){const e=n.ec();n.mc("shippingPrice",n.gc(1,3,e.basketTotals$).shipping)("subtotal",n.gc(2,5,e.basketTotals$).subtotal)("total",n.gc(3,7,e.basketTotals$).total)}}const M=[{path:"",component:(()=>{class e{constructor(e,t,r){this.fb=e,this.accountService=t,this.basketService=r}ngOnInit(){this.initailCheckoutForm(),this.getAddressFormValues(),this.getDeliveryMethodValue(),this.basketTotals$=this.basketService.basketTotal$}initailCheckoutForm(){this.checkoutForm=this.fb.group({addressForm:this.fb.group({firstName:[null,l.p.required],lastName:[null,l.p.required],street:[null,l.p.required],city:[null,l.p.required],state:[null,l.p.required],zipCode:[null,l.p.required]}),deliveryForm:this.fb.group({deliveryMethod:[null,l.p.required]}),paymentForm:this.fb.group({nameOnCard:[null,l.p.required]})})}getAddressFormValues(){this.accountService.getUserAddress().subscribe(e=>{e&&this.checkoutForm.get("addressForm").patchValue(e)},e=>{console.log(e)})}getDeliveryMethodValue(){const e=this.basketService.getCurrentBasketValue();null!==e.deliveryMethodId&&this.checkoutForm.get("deliveryForm").get("deliveryMethod").patchValue(e.deliveryMethodId.toString())}}return e.\u0275fac=function(t){return new(t||e)(n.Pb(l.b),n.Pb(u.a),n.Pb(d.a))},e.\u0275cmp=n.Jb({type:e,selectors:[["app-checkout"]],decls:16,vars:14,consts:[[1,"container","mt-5"],[1,"row"],[1,"col-8"],[3,"linearModeSelected"],["appStepper",""],[3,"label","completed"],[3,"checkoutForm"],[3,"label"],[3,"appStepper"],[1,"col-4"],[3,"shippingPrice","subtotal","total",4,"ngIf"],[3,"shippingPrice","subtotal","total"]],template:function(e,t){if(1&e&&(n.Vb(0,"div",0),n.Vb(1,"div",1),n.Vb(2,"div",2),n.Vb(3,"app-stepper",3,4),n.Vb(5,"cdk-step",5),n.Qb(6,"app-checkout-address",6),n.Ub(),n.Vb(7,"cdk-step",5),n.Qb(8,"app-checkout-delivery",6),n.Ub(),n.Vb(9,"cdk-step",7),n.Qb(10,"app-checkout-review",8),n.Ub(),n.Vb(11,"cdk-step",7),n.Qb(12,"app-checkout-payment",6),n.Ub(),n.Ub(),n.Ub(),n.Vb(13,"div",9),n.Ec(14,O,4,9,"app-order-totals",10),n.fc(15,"async"),n.Ub(),n.Ub(),n.Ub()),2&e){const e=n.wc(4);n.Cb(3),n.mc("linearModeSelected",!0),n.Cb(2),n.mc("label","\u806f\u7d61\u8cc7\u8a0a")("completed",t.checkoutForm.get("addressForm").valid),n.Cb(1),n.mc("checkoutForm",t.checkoutForm),n.Cb(1),n.mc("label","\u904b\u9001\u65b9\u5f0f")("completed",t.checkoutForm.get("deliveryForm").valid),n.Cb(1),n.mc("checkoutForm",t.checkoutForm),n.Cb(1),n.mc("label","\u8a02\u55ae\u78ba\u8a8d"),n.Cb(1),n.mc("appStepper",e),n.Cb(1),n.mc("label","\u7d50\u5e33\u660e\u7d30"),n.Cb(1),n.mc("checkoutForm",t.checkoutForm),n.Cb(2),n.mc("ngIf",n.gc(15,12,t.basketTotals$))}},directives:[p.a,m.a,v,C,S,N,c.m,I.a],pipes:[c.b],styles:[""]}),e})()},{path:"success",component:b,data:{breadcrumb:"\u8a02\u55ae\u5df2\u9001\u51fa"}}];let j=(()=>{class e{}return e.\u0275fac=function(t){return new(t||e)},e.\u0275mod=n.Nb({type:e}),e.\u0275inj=n.Mb({imports:[[i.g.forChild(M)],i.g]}),e})(),A=(()=>{class e{}return e.\u0275fac=function(t){return new(t||e)},e.\u0275mod=n.Nb({type:e}),e.\u0275inj=n.Mb({imports:[[c.c,j,o.a]]}),e})()},mrSG:function(e,t,r){"use strict";function c(e,t,r,c){return new(r||(r=Promise))(function(o,i){function n(e){try{a(c.next(e))}catch(t){i(t)}}function s(e){try{a(c.throw(e))}catch(t){i(t)}}function a(e){var t;e.done?o(e.value):(t=e.value,t instanceof r?t:new r(function(e){e(t)})).then(n,s)}a((c=c.apply(e,t||[])).next())})}r.d(t,"a",function(){return c})}}]);