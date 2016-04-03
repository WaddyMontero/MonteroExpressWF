function BuscarEntidadCallBack(idContenedor,data)
{
    $('#<%= IdEntidad.ClientID %>').val('');
    $('#<%= IdEntidad.ClientID %>').val('');
    if (data != undefined) {
        $('#' + idContenedor + 'txtNombre').val(data.d.Nombre);
        //for(data.d.)

    } else {
        $('#' + idContenedor + 'divControles').removeClass('hidden');
        $('#' + idContenedor + 'divDireccion').removeClass('hidden');
    }
    //if (resultado != undefined) {
       
    //    var tabla = "<table class='table table-responsive'>";
    //    var tabla = "<thead><tr>";
    //    tabla += "<th>Seleccionar</th>";
    //    tabla += "<th>Dirección</th>";
    //    tabla += "<th>Ciudad</th>";
    //    tabla += "<th>Teléfono1</th>";
    //    tabla += "<th>Teléfono2</th>";
    //    tabla += "</tr></thead>"
    //    for (var i = 0; i < resultado.d.length; i++) {
    //        tabla += "<tr>"
    //        tabla += "<td></td>"
    //        tabla += "<td></td>"
    //        tabla += "<td></td>"
    //        tabla += "<td></td>"
    //        tabla += "</tr>"

    //    }
        
    //    MostrarDialogo("Seleccione dirección","")
        

    //} else {

    //}
}


//$('<div></div>').jtable({
//    title: 'Direcciones Entidad',
//    paging: true, //Enable paging
//    sorting: false, //Enable sorting
//    defaultSorting: 'Name ASC',
//    actions: {
//        listAction: '../WebServices/StudentList',
//        deleteAction: '/Demo/DeleteStudent',
//        updateAction: '/Demo/UpdateStudent',
//        createAction: '/Demo/CreateStudent'
//    },
//    fields: {
//        StudentId: {
//            key: true,
//            create: false,
//            edit: false,
//            list: false
//        },
//        Name: {
//            title: 'Name',
//            width: '15%'
//        },
//        EmailAddress: {
//            title: 'Email address',
//            list: false
//        },
//        Password: {
//            title: 'User Password',
//            type: 'password',
//            list: false
//        },
//        Gender: {
//            title: 'Gender',
//            width: '12%',
//            options: { 'M': 'Male', 'F': 'Female' }
//        },
//        CityId: {
//            title: 'Living city',
//            width: '15%',
//            options: '/Demo/GetCityOptions'
//        },
//        BirthDate: {
//            title: 'Birth date',
//            width: '18%',
//            type: 'date',
//            displayFormat: 'yy-mm-dd'
//        },
//        Education: {
//            title: 'Education',
//            list: false,
//            type: 'radiobutton',
//            options: { '1': 'Primary school', '2': 'High school', '3': 'University' }
//        },
//        About: {
//            title: 'About this person',
//            type: 'textarea',
//            list: false
//        },
//        IsActive: {
//            title: 'Status',
//            width: '10%',
//            type: 'checkbox',
//            values: { 'false': 'Passive', 'true': 'Active' },
//            defaultValue: 'true'
//        },
//        RecordDate: {
//            title: 'Record date',
//            width: '18%',
//            type: 'date',
//            displayFormat: 'yy-mm-dd',
//            create: false,
//            edit: false
//        }
//    },
//    //Initialize validation logic when a form is created
//    formCreated: function (event, data) {
//        data.form.find('input[name="Name"]').addClass('validate[required]');
//        data.form.find('input[name="EmailAddress"]').addClass('validate[required,custom[email]]');
//        data.form.find('input[name="Password"]').addClass('validate[required]');
//        data.form.find('input[name="BirthDate"]').addClass('validate[required,custom[date]]');
//        data.form.find('input[name="Education"]').addClass('validate[required]');
//        data.form.validationEngine();
//    },
//    //Validate form when it is being submitted
//    formSubmitting: function (event, data) {
//        return data.form.validationEngine('validate');
//    },
//    //Dispose validation logic when form is closed
//    formClosed: function (event, data) {
//        data.form.validationEngine('hide');
//        data.form.validationEngine('detach');
//    }
//});

////Load student list from server
//$('#StudentTableContainer').jtable('load');