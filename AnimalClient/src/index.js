import $, { get } from "jquery";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import "./css/styles.css";

const tunnelUrl = `http://localhost:5050/api/Animals`;

//GET
async function getData() {
  try {
    const response = await fetch(tunnelUrl);
    if (!response.ok) {
      throw Error(response.statusText);
    }
    return response.json();
  } catch (error) {
    return error.message;
  }
}

// POST
async function postData(data) {
  fetch(tunnelUrl, {
    method: "POST", // or 'PUT'
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });
}

//DELETE
async function deleteData(animalId, userName) {
  fetch(`${tunnelUrl}/${animalId}/${userName}`, {
    method: "DELETE",
  });
}

//PUT
async function putData(animalId, userName, data) {
  data["animalId"] = animalId;
  fetch(`${tunnelUrl}/${animalId}/${userName}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });
}

//get list of locations
async function appendData() {
  let response = await getData().then(function (response) {
    response.forEach((element) => {
      $(".apiPlaces").append(
        `<div>
        <h1>${element.family}</h1>
        <h4>Age: ${element.age}</h4>
        <h4>Sex: ${element.sex}</h4>
        <h4>Admission: ${element.admission}</h4>
        <h4>Breed: ${element.breed}</h4>
        <h4>Posted by: ${element.userName}</h4>
        <small>${element.animalId}</small>
        <button ="btn btn-danger" class="deletePlace" id=${element.animalId},${element.userName}>Delete</button>
        <button class="editPlace" id="${element.animalId},${element.family},${element.age},${element.sex},${element.admission},${element.breed},${element.userName}">Edit</button>
        <hr>
        </div>`
      );
    });
  });
  //update event handler for dynamically added buttons
  updateHandler();
}

//find all buttons for delete and edit and attach event handlers
function updateHandler() {
  //for delete buttons
  $("button.deletePlace").click(function () {
    const animalId = $(this).attr("id").split(",")[0];
    const userName = $(this).attr("id").split(",")[1];
    deleteData(animalId, userName);
    $(this).closest("div").remove();
  });

  //for edit buttons
  $("button.editPlace").click(function () {
    const animalId = $(this).attr("id").split(",")[0];
    const family = $(this).attr("id").split(",")[1];
    const age = $(this).attr("id").split(",")[2];
    const sex = $(this).attr("id").split(",")[3];
    const admission = $(this).attr("id").split(",")[4];
    const breed = $(this).attr("id").split(",")[5];
    const userName = $(this).attr("id").split(",")[6];
    //change values of text boxes in footer
    $("div.upperStatic").html(
      `<input type="number" id="animalId" placeholder="animal id"/>`
    );
    $("select#method").val("edit");
    $("input#animalId").val(animalId);
    $("input#userName").val(userName);
    $("input#family").val(family);
    $("input#age").val(age);
    $("input#sex").val(sex);
    $("input#admission").val(admission);
    $("input#breed").val(breed);
  });
}

$(document).ready(async function () {
  appendData();

  //on select option change within footer
  $("select#method").change(function () {
    if ($("select#method option:checked").val() == "edit") {
      $("div.upperStatic").append(
        `<input type="number" id="animalId" placeholder="animal id"/>`
      );
    } else {
      $("input#animalId").remove();
    }
  });

  //when post button is submitted
  $("button#submit").click(function () {
    const animalId = $("#animalId").val();
    const family = $("#family").val();
    const age = $("#age").val();
    const sex = $("#sex").val();
    const admission = $("#admission").val();
    const breed = $("#breed").val();
    const userName = $("#userName").val();
    const data = {
      family: family,
      age: age,
      sex: sex,
      admission: admission,
      breed: breed,
      userName: userName,
    };

    switch ($("select#method option:checked").val()) {
      case "create":
        postData(data);
        break;
      case "edit":
        putData(animalId, userName, data);
        break;
      default:
        location.reload();
        break;
    }
    setTimeout(() => {
      location.reload();
    }, 500);
  });
});