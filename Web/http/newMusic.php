<?php
/*
Author : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
require_once("php/functions.php");
session_start();

// CheckConnexion and admin
CheckConnexion();
CheckAdmin();
//Check if all the data is correct and set
if(isset($_POST['idArtist']) && isset($_POST['idType']) && isset($_POST['titleToAdd']) && $_POST['titleToAdd'] != null && isset($_FILES['fileToAdd']) && $_FILES['fileToAdd']['type'] == 'audio/mp3'){
  $imagePath = 'Music/';
  //Generate a unique name
  $uniquesavename=time().uniqid(rand()) . '.mp3';
  $destFile = $imagePath . $uniquesavename;
  $filename = $_FILES["fileToAdd"]["tmp_name"];
  //Save the file
  move_uploaded_file($filename,  $destFile);
  //http://stackoverflow.com/questions/36030621/create-a-unique-name-for-the-uploaded-image
  //Insert the data in the database
  $sql = "INSERT INTO musics (titleMusic,idType,idArtist,fileName) VALUES (:title,:idType,:idArtist,:file)";
  $query = $db->prepare($sql);
  $query->execute(array(
    'title' => htmlentities($_POST['titleToAdd']),
    'idType' => htmlentities($_POST['idType']),
    'idArtist' => htmlentities($_POST['idArtist']),
    'file' => $uniquesavename
  ));
}
header("Location: admin.php");
