<?php
require_once("php/functions.php");
session_start();
if (isset($_POST['usersToDel'])) {
  foreach ($_POST['usersToDel'] as $idToDel) {
    $sql = "";
    $query = $db->prepare($sql);
  }
}
