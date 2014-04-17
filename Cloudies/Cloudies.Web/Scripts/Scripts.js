﻿var App = {
    create_new_participant_row: function (options) {
        var participantIndex = options.Index;
        var Username = (options.Email_Address) ? options.Email_Address : "";
        var First_Name = (options.First_Name) ? options.First_Name : "";
        var Last_Name = (options.Last_Name) ? options.Last_Name : "";
        var Selected = (options.Role) ? options.Role : "Guest";

        var newParticipantRow = $("<div/>", { class: "form-horizontal no-overflow new-participant-row participant-row" });
        var rowIndex = $("<span/>", { class: "new-participant-row-index" });
        rowIndex.html(participantIndex + 1)
        var firstRow = $("<div/>", { class: "add-participant-row-1"});
        var secondRow = $("<div/>", { class: "add-participant-row-2" });
        var participantId = "Participants[" + participantIndex + "].";

        var usernameContainer = $("<div/>", { class: "form-group col-md-5" })
        var usernameLabel = $("<label>", { class: "control-label col-md-5", for: participantId + "Username", html: "Username"});
        var usernameInputContainer = $("<div/>", { class: "col-md-7" });
        var usernameInput = $("<input/>", { id: participantId + "Username", type: "text", class: "form-control", name: participantId + "Username", value: Username })

        var roleContainer = $("<div/>", { class: "form-group col-md-5" });
        var roleLabel = $("<label/>", { class: "control-label col-md-5", for: participantId + "Role", html: "Role" });
        var roleInputContainer = $("<div/>", { class: "col-md-7" });
        var roleInput = $("<select/>", { class: "form-control", id: participantId + "Role", name: participantId + "Role" });
        var roleOptions = {
            "Guest": $("<option/>", { value: "Guest", html: "Guest" }),
            "Admin": $("<option/>", { value: "Admin", html: "Admin" })
        }

        var firstNameContainer = $("<div/>", { class: "form-group col-md-5" });
        var firstNameLabel = $("<label/>", { class: "control-label col-md-5", for: participantId + "First_Name", html: "First name" });
        var firstNameInputContainer = $("<div/>", { class: "col-md-7" });
        var firstNameInput = $("<input/>", { class: "form-control", id: participantId + "First_Name", name: participantId + "First_Name", value: First_Name })

        var lastNameContainer = $("<div/>", { class: "form-group col-md-5" });
        var lastNameLabel = $("<label/>", { class: "control-label col-md-5", for: participantId + "Last_Name", html: "Last name" });
        var lastNameInputContainer = $("<div/>", { class: "col-md-7" });
        var lastNameInput = $("<input/>", { class: "form-control", id: participantId + "Last_Name", name: participantId + "Last_Name", value: Last_Name })

        newParticipantRow.append(rowIndex);
        newParticipantRow.append(firstRow);
        newParticipantRow.append(secondRow);

        firstRow.append(usernameContainer);
        usernameContainer.append(usernameLabel);
        usernameContainer.append(usernameInputContainer);
        usernameInputContainer.append(usernameInput);

        firstRow.append(roleContainer);
        roleContainer.append(roleLabel);
        roleContainer.append(roleInputContainer);
        roleInputContainer.append(roleInput);
        for(role in roleOptions) {
            roleInput.append(roleOptions[role])
        }

        secondRow.append(firstNameContainer);
        firstNameContainer.append(firstNameLabel);
        firstNameContainer.append(firstNameInputContainer);
        firstNameInputContainer.append(firstNameInput);
        roleOptions[Selected].attr("selected", "");

        secondRow.append(lastNameContainer);
        lastNameContainer.append(lastNameLabel);
        lastNameContainer.append(lastNameInputContainer);
        lastNameInputContainer.append(lastNameInput)

        $("#lab-participant-list-editor").append(newParticipantRow)
    }
}

$(function () {
    $("#add-new-participant-row").click(function (e) {
        e.preventDefault();
        count = Number($(this).attr("count"));
        App.create_new_participant_row({ Index: count });
        $(this).attr("count", ++count);
        return false;
    })
})