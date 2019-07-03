<?php

header ( 'Content-type: application/json' );
include "db.php";
$response = array();
$ok = true;
if(!isset($_REQUEST['email'])){
	$ok=false;
	$response['status'] = 'Please Set email';
}
else if(!isset($_REQUEST['username'])){
	$ok = false;
	$response['status'] = 'Please Set username';

}
else if(!isset($_REQUEST['password'])){
	$ok = false;
	$response['status'] = 'Please Set password';

} else{
  	$email = $_REQUEST['email'];
	$user = $_REQUEST['username'];
	$pass = $_REQUEST['password'];
}

if($ok){
	$db = new db();
	$db -> connect();
	$sql	="INSERT INTO `Pet_User` (`email`, `username`, `password`)
          VALUES ('$email', '$user', '$pass')";
	if($db->query($sql)){
		$response['status'] = 1;
	}else{
		$response['status'] = 0;
	}
}

echo json_encode($response);
?>
