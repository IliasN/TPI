<?php
require_once("php/functions.php");
session_start();
if (isset($_POST['usersToDel'])) {
  foreach ($_POST['usersToDel'] as $idToDel) {
    $sql = "DELETE FROM users WHERE idUser = :id";
    $query = $db->prepare($sql);
    $query->execute(array(
      'id' => $idToDel
    ));
  }
  header("Location: manageUsers.php");
}
