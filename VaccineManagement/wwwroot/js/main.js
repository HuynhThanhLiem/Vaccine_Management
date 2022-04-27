;(function () {
	
	'use strict';



	var isMobile = {
		Android: function() {
			return navigator.userAgent.match(/Android/i);
		},
			BlackBerry: function() {
			return navigator.userAgent.match(/BlackBerry/i);
		},
			iOS: function() {
			return navigator.userAgent.match(/iPhone|iPad|iPod/i);
		},
			Opera: function() {
			return navigator.userAgent.match(/Opera Mini/i);
		},
			Windows: function() {
			return navigator.userAgent.match(/IEMobile/i);
		},
			any: function() {
			return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
		}
	};

	var fullHeight = function() {

		if ( !isMobile.any() ) {
			$('.js-fullheight').css('height', $(window).height());
			$(window).resize(function(){
				$('.js-fullheight').css('height', $(window).height());
			});
		}

	};

	// Animations

	var contentWayPoint = function() {
		var i = 0;
		$('.animate-box').waypoint( function( direction ) {

			if( direction === 'down' && !$(this.element).hasClass('animated') ) {
				
				i++;

				$(this.element).addClass('item-animate');
				setTimeout(function(){

					$('body .animate-box.item-animate').each(function(k){
						var el = $(this);
						setTimeout( function () {
							var effect = el.data('animate-effect');
							if ( effect === 'fadeIn') {
								el.addClass('fadeIn animated');
							} else if ( effect === 'fadeInLeft') {
								el.addClass('fadeInLeft animated');
							} else if ( effect === 'fadeInRight') {
								el.addClass('fadeInRight animated');
							} else {
								el.addClass('fadeInUp animated');
							}

							el.removeClass('item-animate');
						},  k * 200, 'easeInOutExpo' );
					});
					
				}, 100);
				
			}

		} , { offset: '85%' } );
	};


	var burgerMenu = function() {

		$('.js-fh5co-nav-toggle').on('click', function(event){
			event.preventDefault();
			var $this = $(this);

			if ($('body').hasClass('offcanvas')) {
				$this.removeClass('active');
				$('body').removeClass('offcanvas');	
			} else {
				$this.addClass('active');
				$('body').addClass('offcanvas');	
			}
		});



	};

	// Click outside of offcanvass
	var mobileMenuOutsideClick = function() {

		$(document).click(function (e) {
	    var container = $("#fh5co-aside, .js-fh5co-nav-toggle");
	    if (!container.is(e.target) && container.has(e.target).length === 0) {

	    	if ( $('body').hasClass('offcanvas') ) {

    			$('body').removeClass('offcanvas');
    			$('.js-fh5co-nav-toggle').removeClass('active');
			
	    	}
	    	
	    }
		});

		$(window).scroll(function(){
			if ( $('body').hasClass('offcanvas') ) {

    			$('body').removeClass('offcanvas');
    			$('.js-fh5co-nav-toggle').removeClass('active');
			
	    	}
		});

	};

	var sliderMain = function() {
		
	  	$('#fh5co-hero .flexslider').flexslider({
			animation: "fade",
			slideshowSpeed: 5000,
			directionNav: true,
			start: function(){
				setTimeout(function(){
					$('.slider-text').removeClass('animated fadeInUp');
					$('.flex-active-slide').find('.slider-text').addClass('animated fadeInUp');
				}, 500);
			},
			before: function(){
				setTimeout(function(){
					$('.slider-text').removeClass('animated fadeInUp');
					$('.flex-active-slide').find('.slider-text').addClass('animated fadeInUp');
				}, 500);
			}

	  	});

	};
	
	// Document on load.
	$(function () {
		fullHeight();
		contentWayPoint();
		burgerMenu();
		mobileMenuOutsideClick();
		sliderMain();
	});


}());

// Open Delete		
//const deletewrapper = document.querySelector('.vaccine-delete-wrapper');
//const vaccinedeletepopup= document.querySelector('.vaccine-delete');
//let deleteicon = document.querySelectorAll('.delete-real');
//deleteicon = Array.from(deleteicon);

//for (var i = 0; i < deleteicon.length; i++) {


//	const handledelete = () => {
//		deletewrapper.style.display = 'flex';
//	}
//	deleteicon[i].addEventListener('click', handledelete);
//}


//// Out deletevaccinedeletepopup

//let outicon = document.querySelector('.out-delete-vaccine');

//const handleoutdelete = () => {
//	deletewrapper.style.display = 'none';
//}
//outicon?.addEventListener('click', handleoutdelete);

//const cancelicon =document.querySelector('.out-cancel-vaccine')
//cancelicon?.addEventListener('click', handleoutdelete);
	
//const handleoutdelete2 = ()=> {
//	vaccinedeletepopup.addEventListener('click',handledeletepopup= (e) => e.stopPropagation())
//	deletewrapper.style.display = 'none';
//}
//deletewrapper?.addEventListener('click',handleoutdelete2)

//const regvaccineappear = document.querySelector('.vaccine-table-search');
//const search_main_btn = document.querySelector('.search-main-btn-2');

//const appeartablereg = () => {
//	regvaccineappear.style.display='flex';
//}

//search_main_btn?.addEventListener('click',appeartablereg)

// Onclick edit vaccine
//let editicon = document.querySelectorAll('.edit-real');
//editicon = Array.from(editicon);
//const backList = document.querySelector('.fh5co-body-edit-backlist');
//const tableEditVaccine=document.querySelector('.fh5co-narrow-content-2');
//const EditcancelBackToVaccine = document.querySelector('.cancel-back-to-vaccine');
//const tableVaccine=document.querySelector('.create-table-all');
//const backList2 = document.querySelector('.fh5co-body-create-backlist');
//for (var i = 0; i < editicon.length; i++) {
//	const handleEdit = () => {
//		tableVaccine.style.display='none';
//		tableEditVaccine.style.display='block';
//	}
//	editicon[i].addEventListener('click',handleEdit);
//}

//const handleBackVaccine = () => {
//	tableEditVaccine.style.display='none';
//	tableVaccine.style.display='block';
//}

//backList?.addEventListener('click',handleBackVaccine)
//backList2?.addEventListener('click',handleBackVaccine)
//EditcancelBackToVaccine?.addEventListener('click',handleBackVaccine)


// Onclick create vaccine
//const createbuttonvc = document.querySelector('.fh5co-head-create-chuyen');
//const tableCreateVaccine = document.querySelector('.fh5co-head-create-new');
//const cancelBackToVaccine = document.querySelector('.fh5co-body-create-btn-cancel');
//const handleCreateVaccine = () => {
//	tableVaccine.style.display='none';
//	tableCreateVaccine.style.display='block';
	
//}
//const cancelBackToVaccines = () => {
//	tableCreateVaccine.style.display='none';
//	tableVaccine.style.display='block';
//}
//createbuttonvc?.addEventListener('click',handleCreateVaccine)
//cancelBackToVaccine?.addEventListener('click',cancelBackToVaccines)
//backList2?.addEventListener('click',cancelBackToVaccines)

// (function () {
// 	'use strict'
// 	var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
// 	tooltipTriggerList.forEach(function (tooltipTriggerEl) {
// 	  new bootstrap.Tooltip(tooltipTriggerEl)
// 	})
//   })()



function Redirect() {
	alert('Bạn có chắc muốn quay trở lại trang chủ!')
	window.location="./home.html";
}

const option1 = document.querySelector('.option-search-inject');
const option2 = document.querySelector('.option-search-inject2');
const form1 = document.querySelector('.search-main-main');
const form2 = document.querySelector('.search-main-main-4');

const obtaintolookup = () => {
	form1.style.display='flex';
	form2.style.display='none';
	regvaccineappear.style.display='none';
}

const lookuptoobtain = () => {
	form1.style.display='none';
	
	form2.style.display='flex';
	
}

option1?.addEventListener('click',obtaintolookup)
option2?.addEventListener('click',lookuptoobtain)

const login_form = document.querySelector('.signInWrap');
const login = document.querySelector('.fh5co-main-menu-login');
const sideBar = document.querySelector('#fh5co-aside')


const chooselogin = () => {
	login_form.style.display = "flex";
	sideBar.style.zIndex = 0;
}

login?.addEventListener('click', chooselogin)
const exit_Icon = document.querySelector('.signIn_form > i');
const form_Wrapper = document.querySelector('.signInWrap');
const form = document.querySelector('.signIn');



const chooseExit_icon = () => {
	login_form.style.display = "none";
	sideBar.style.zIndex = 999;
}

exit_Icon?.addEventListener('click',chooseExit_icon)

const exit_Icon2 = document.querySelector('.SignUp_form > i');


const chooseExit_icon2 = () => {
	signup_form.style.display = "none";
	sideBar.style.zIndex = 999;
}

exit_Icon2?.addEventListener('click',chooseExit_icon2)

const chooseform_Wrapper = () => {
	login_form.style.display = "none";
	sideBar.style.zIndex = 999;
}

form_Wrapper?.addEventListener('click',chooseform_Wrapper);

const chooseform = (e) => {
	e.stopPropagation();
}

form?.addEventListener('click',chooseform)

// -----------------------------------------------------------------------


$('.collapse').collapse()
// ----------------------------------------------------------------------------
const footer = document.querySelector('.fh5co-footer');
const search_button = document.querySelector('.accordion-button');
const search_button_collapse =  document.querySelector('.collapsed');
var footer_appear = true;

const clickSeacrh = () => {
	if (footer_appear) {
		footer.style.display = "none";
		footer_appear=false;
	}
	else
	{
		footer.style.display = 'block';
		footer_appear = true;
	}
}
	
search_button?.addEventListener('click',clickSeacrh)

// -------------------------------------------------------------------
const register_btn = document.querySelector('.up-to-register');
const signup_form =document.querySelector('.SignUpWrap')
const clickhandleregister = () => {
	
	login_form.style.display = 'none';
	signup_form.style.display= 'flex';
}
register_btn?.addEventListener('click',clickhandleregister)

const login_btn = document.querySelector('.up-to-login');
const clickhandlelogin = () => {
	login_form.style.display = 'flex';
	signup_form.style.display= 'none';
}
login_btn?.addEventListener('click',clickhandlelogin);

const signuphelp = document.querySelector('.SignUp')
const chooseform_Wrapper2 = () => {
	signup_form.style.display = "none";
	sideBar.style.zIndex = 999;
}

signup_form?.addEventListener('click',chooseform_Wrapper2);

const chooseform2 = (e) => {
	e.stopPropagation();
}

signuphelp?.addEventListener('click',chooseform2)

const logout_form = document.querySelector('.logout-right-now')
const logout_btn =document.querySelector('.fh5co-main-menu-logout');


const chooseLogout = () => {
	
	logout_form.style.display = 'flex';
}

logout_btn?.addEventListener('click',chooseLogout)

const outlogout = document.querySelector('.out-logout-vaccine');
const outcancellogout = document.querySelector('.out-cancel-logout');
const logoutnow = document.querySelector('.logout-right-now-pls');
const outlogout2 = () => {
	logout_form.style.display = 'none';
}

outlogout?.addEventListener('click',outlogout2)
outcancellogout?.addEventListener('click',outlogout2)
logout_form?.addEventListener('click',outlogout2)

const notoutnow = (e) => {
	e.stopPropagation();
}

logoutnow?.addEventListener('click',notoutnow)

const forgotbutton = document.querySelector('.forgot-password-btn');
const forgot_form = document.querySelector('.forgot-password-wrap')
const chooseForgotbtn = () => {
	login_form.style.display='none';
	forgot_form.style.display = 'flex';
}
forgotbutton?.addEventListener('click',chooseForgotbtn)
const forgotPassword = document.querySelector('.forgot-password');
const outcancelforgot = document.querySelector('.out-cancel-forgot');
const forgotpwreal = document.querySelector('.forgot-password-sure');

const forgotPasswordhandle = () => {
	forgot_form.style.display = 'none';
}

forgotPassword?.addEventListener('click',forgotPasswordhandle)
outcancelforgot?.addEventListener('click',forgotPasswordhandle)
forgot_form?.addEventListener('click',forgotPasswordhandle)

const forgot = (e) => {
	e.stopPropagation();
}

forgotpwreal?.addEventListener('click',forgot)

const submit_fg_btn = document.querySelector('.submit-btn-forgot');
const forgot_form_success = document.querySelector('.submit-forgot-password-wrap')
const confirmRegistration = document.querySelector('.vaccine-consent-form-agree-btn-3');
const confirmTrueReg = () => {
	forgot_form_success.style.display="flex";
}

confirmRegistration?.addEventListener('click',confirmTrueReg)
const chooseSubmitForgotBtn = () => {
	console.log(1)
	forgot_form_success.style.display='flex';
	forgot_form.style.display = 'none';
}

submit_fg_btn?.addEventListener('click',chooseSubmitForgotBtn)

const forgotPasswordSc = document.querySelector('.forgot-password-sc');
const outcancelforgotsc = document.querySelector('.out-cancel-forgot-sc');
const forgotpwrealsc = document.querySelector('.forgot-password-sure-sc');

const forgotPasswordSchandle = () => {
	forgot_form_success.style.display = 'none';
}

forgotPasswordSc?.addEventListener('click',forgotPasswordSchandle)
outcancelforgotsc?.addEventListener('click',forgotPasswordSchandle)
forgot_form_success?.addEventListener('click',forgotPasswordSchandle)

const forgotsc = (e) => {
	e.stopPropagation();
}

forgotpwrealsc?.addEventListener('click',forgotsc);

const backToLogin = document.querySelector('.backlogin-btn');
const backToLoginhandle = () => {
	
	forgot_form_success.style.display = 'none';
	login_form.style.display='flex';
}

backToLogin?.addEventListener('click',backToLoginhandle)

//eye_password
var eye1 = document.querySelector(".signup-psw-1");
	var eye2 = document.querySelector(".signup-psw-2");
	var input1 = document.querySelector(".input-psw-signup");
	
	var eye3 = document.querySelector(".confirm-psw-1");
	var eye4 = document.querySelector(".confirm-psw-2");
	var input2 = document.querySelector(".input-psw-confirm");
	
	var eye5 = document.querySelector(".signin-psw-1");
	var eye6 = document.querySelector(".signin-psw-2");
	var input3 = document.querySelector(".input-psw-signin");
	
	function myFunction1() {				
	if (input1.type === "password") {
		eye1.style.display = "none";
		eye2.style.display = "block";
		input1.type = "text";
	} else {
		input1.type = "password";	
		eye2.style.display = "none";
		eye1.style.display = "block";
	}
	}
	function myFunction2() {
		if (input1.value != "") {
			if (input1.type === "password") {				
				eye2.style.display = "block";			
			} else {				
				eye1.style.display = "block";
			}
		} else {
			eye1.style.display = "none";
			eye2.style.display = "none";
		}		
	}

	function myFunction3() {	
	if (input2.type === "password") {
		eye3.style.display = "none";
		eye4.style.display = "block";
		input2.type = "text";
	} else {
		input2.type = "password";
		eye4.style.display = "none";
		eye3.style.display = "block";
	}
	}
	function myFunction4() {
		if (input2.value != "") {
			if (input2.type === "password") {				
				eye4.style.display = "block";			
			} else {				
				eye3.style.display = "block";
			}
		} else {
			eye3.style.display = "none";
			eye4.style.display = "none";
		}		
	}
	function myFunction5() {	
	if (input3.type === "password") {
		eye5.style.display = "none";
		eye6.style.display = "block";
		input3.type = "text";
	} else {
		input3.type = "password";
		eye6.style.display = "none";
		eye5.style.display = "block";
	}
	}
	function myFunction6() {
		if (input3.value != "") {
			if (input3.type === "password") {				
				eye6.style.display = "block";			
			} else {				
				eye5.style.display = "block";
			}
		} else {
			eye5.style.display = "none";
			eye6.style.display = "none";
		}		
	}	


//filter_report
/*
Please consider that the JS part isn't production ready at all, I just code it to show the concept of merging filters and titles together !
*/
$(document).ready(function(){
    $('.filterable .btn-filter').click(function(){
        var $panel = $(this).parents('.filterable'),
        $filters = $panel.find('.filters input'),
        $tbody = $panel.find('.table tbody');
        if ($filters.prop('disabled') == true) {
            $filters.prop('disabled', false);
            $filters.first().focus();
        } else {
            $filters.val('').prop('disabled', true);
            $tbody.find('.no-result').remove();
            $tbody.find('tr').show();
        }
    });

    $('.filterable .filters input').keyup(function(e){
        /* Ignore tab key */
        var code = e.keyCode || e.which;
        if (code == '9') return;
        /* Useful DOM data and selectors */
        var $input = $(this),
        inputContent = $input.val().toLowerCase(),
        $panel = $input.parents('.filterable'),
        column = $panel.find('.filters th').index($input.parents('th')),
        $table = $panel.find('.table'),
        $rows = $table.find('tbody tr');
        /* Dirtiest filter function ever ;) */
        var $filteredRows = $rows.filter(function(){
            var value = $(this).find('td').eq(column).text().toLowerCase();
            return value.indexOf(inputContent) === -1;
        });
        /* Clean previous no-result if exist */
        $table.find('tbody .no-result').remove();
        /* Show all rows, hide filtered ones (never do that outside of a demo ! xD) */
        $rows.show();
        $filteredRows.hide();
        /* Prepend no-result row if all rows are filtered */
        if ($filteredRows.length === $rows.length) {
            $table.find('tbody').prepend($('<tr class="no-result text-center"><td colspan="'+ $table.find('.filters th').length +'">No result found</td></tr>'));
        }
    });
});


