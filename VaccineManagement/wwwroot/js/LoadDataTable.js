$(document).ready(function () {

    loadDataTableVCine();
    loadDataTableVBatch();
    loadDataTableCities();
    loadDataTableDistricts();
    loadDataTableWards();
    loadDataTableDistribution();
    loadDataTableAnamnesis();
    loadDataTableDeclar();
    loadDataTableCitizen();
    loadDataTableStaff();
    loadDataTableReg();
    loadDataTableVaccination();
});

//Vaccine Table
function loadDataTableVCine() {
    var dataTableVCine = $('#DT_load_vcine').DataTable({
        "ajax": {
            "url": "/admin/vaccines/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "vaccineId", "width": "10%"},
            { "data": "name", "width": "15%" },
            { "data": "origin", "width": "15%" },
            { "data": "maxRange", "width": "15%" },
            { "data": "expired", "width": "15%" },
            { "data": "doses", "width": "15%" },
            {
                "data": "vaccineId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Vaccines/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Vaccines/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "language": {
                "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Vaccine Batch
function loadDataTableVBatch() {
    var dataTableVBatch = $('#DT_load_vbatch').DataTable({
        "ajax": {
            "url": "/admin/batch/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "batchId", "width": "10%" },
            { "data": "name", "width": "15%" },
            { "data": "importedDate", "width": "15%" },
            { "data": "quantity", "width": "10%" },
            { "data": "producedDate", "width": "15%" },
            { "data": "expiredDate", "width": "15%" },
            {
                "data": "batchId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Batch/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Batch/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "columnDefs": [{
            "targets": [2,4,5],
            "render": function (data) {
                return data.split('T')[0];
            },
        }],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Cities
function loadDataTableCities() {
    var dataTableCities = $('#DT_load_cities').DataTable({
        "ajax": {
            "url": "/admin/cities/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "cityId", "width": "20%" },
            { "data": "cityName", "width": "60%" },
            {
                "data": "cityId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Cities/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Cities/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Districts
function loadDataTableDistricts() {
     var dataTableDistricts = $('#DT_load_district').DataTable({
        "ajax": {
            "url": "/admin/districts/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "cityName", "width": "20%" },
            { "data": "districtName", "width": "20%" },
            {
                "data": "districtId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Districts/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Districts/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Ward Table
function loadDataTableWards() {
    var dataTableWards = $('#DT_load_ward').DataTable({
        "ajax": {
            "url": "/admin/wards/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "districtName", "width": "20%" },
            { "data": "wardName", "width": "20%" },
            {
                "data": "wardId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Wards/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Wards/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Distribution Table
function loadDataTableDistribution() {
    var dataTableDistribution = $('#DT_load_distribution').DataTable({
        "ajax": {
            "url": "/admin/distribution/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "batchId", "width": "15%" },
            { "data": "cityName", "width": "15%" },
            { "data": "quantityVaccine", "width": "15%" },
            { "data": "shippedDate", "width": "15%" },
            {
                "data": "batchId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Distribution/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Distribution/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "columnDefs": [{
            "targets": 3,
            "render": function (data) {
                return data.split('T')[0];
            },
        }],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Anamnesis Table
function loadDataTableAnamnesis() {
    var dataTableDistribution = $('#DT_load_anamnesis').DataTable({
        "ajax": {
            "url": "/admin/anamnesis/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "anaphylaxis", "width": "10%" },
            { "data": "lowImmunity", "width": "10%" },
            { "data": "acuteIllness", "width": "10%" },
            { "data": "allergy", "width": "10%" },
            { "data": "older", "width": "10%" },
            { "data": "pregnancy", "width": "10%" },
            { "data": "bloodDisorder", "width": "10%" },
            { "data": "useInhibition", "width": "10%" },
            { "data": "developChronic", "width": "10%" },
            { "data": "curedChronic", "width": "10%" },
            { "data": "vaccineedHalfMonth", "width": "10%" },
            { "data": "covidSixMonths", "width": "10%" },
            {
                "data": "anamnesisId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Anamnesis/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Anamnesis/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Citizen Table
function loadDataTableCitizen() {
    var dataTableCitizen = $('#DT_load_ctz').DataTable({
        "ajax": {
            "url": "/admin/citizen/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idCard", "width": "10%" },
            { "data": "fullName", "width": "10%" },
            { "data": "gender", "width": "10%" },
            { "data": "dateOfBirth", "width": "10%" },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "email", "width": "10%" },
            { "data": "address", "width": "10%" },
            { "data": "healthInsurance", "width": "10%" },
            { "data": "job", "width": "10%" },
            { "data": "company", "width": "10%" },
            { "data": "nation", "width": "10%" },
            { "data": "nationality", "width": "10%" },
            {
                "data": "citizenId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Citizen/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Citizen/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "columnDefs": [{
            "targets": 3,
            "render": function (data) {
                return data.split('T')[0];
            },
        }],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Declaration
function loadDataTableDeclar() {
    var dataTableDeclar = $('#DT_load_declar').DataTable({
        "ajax": {
            "url": "/admin/declaration/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "citizenId", "width": "15%" },
            { "data": "hasSymptom", "width": "15%" },
            { "data": "contactSymptom", "width": "15%" },
            { "data": "contactForeigner", "width": "15%" },
            { "data": "contactCovidPerson", "width": "15%" },
            { "data": "fromCovidPlace", "width": "15%" },
            { "data": "declaratedDate", "width": "15%" },
            {
                "data": "healthDeclarId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Declaration/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Declaration/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "columnDefs": [{
            "targets": 6,
            "render": function (data) {
                return data.split('T')[0];
            },
        }],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Medical Staff Table
function loadDataTableStaff() {
    var dataTableStaff = $('#DT_load_staff').DataTable({
        "ajax": {
            "url": "/admin/staff/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "staffId", "width": "10%" },
            { "data": "fullName", "width": "25%" },
            { "data": "phoneNumber", "width": "10%" },
            { "data": "email", "width": "10%" },
            { "data": "assignment", "width": "10%" },
            {
                "data": "staffId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Staff/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Staff/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Vaccine Registration Table
function loadDataTableReg() {
    var dataTableReg = $('#DT_load_reg').DataTable({
        "ajax": {
            "url": "/admin/registration/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registrationId", "width": "10%" },
            { "data": "citizenId", "width": "5%" },
            { "data": "anamnesisId", "width": "10%" },
            { "data": "agreement", "width": "15%" },
            { "data": "choiceInjections", "width": "10%" },
            { "data": "registratedDate", "width": "20%" },
            { "data": "status", "width": "15%" },
            {
                "data": "registrationId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Registration/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Registration/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "columnDefs": [{
            "targets": 5,
            "render": function (data) {
                return data.split('T')[0];
            },
        }],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Vaccination Table
function loadDataTableVaccination() {
    var dataTableVaccination = $('#DT_load_vcnation').DataTable({
        "ajax": {
            "url": "/admin/vaccination/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "vaccinationId", "width": "10%" },
            { "data": "cityId", "width": "5%" },
            { "data": "registrationId", "width": "10%" },
            { "data": "staffId", "width": "15%" },
            { "data": "batchId", "width": "10%" },
            { "data": "vaccineedDate", "width": "20%" },
            {
                "data": "vaccinationId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Vaccination/Upsert?id=${data}"><i class="edit-real fas fa-pen"></i></a>
                        &nbsp;
                        <a onclick="Delete('/Admin/Vaccination/Delete?id='+${data})"><i class="delete-real fas fa-trash"></i></a>
                        </div>`;
                }, "width": "25%"
            }
        ],
        "columnDefs": [{
            "targets": 5,
            "render": function (data) {
                return data.split('T')[0];
            },
        }],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

//Delete Ajax
function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: ["Cancel", "Delete"],
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTableVCine.ajax.reload();
                        dataTableVBatch.ajax.reload();
                        dataTableCities.ajax.reload();
                        dataTableDistricts.ajax.reload();
                        dataTableWards.ajax.reload();
                        dataTableDistribution.ajax.reload();
                        dataTableAnamnesis.ajax.reload();
                        dataTableDeclar.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}

