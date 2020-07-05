<?php
if(isset($_GET['code']) && isset($_GET['ClientsNameJavaw'])
&& isset($_GET['ClientsNameExplorer'])
&& isset($_GET['ClientsNameLsass']))
{
	if(!empty($_GET['code']))
	{
		
		//include('modele/config/fonctions_speciales.php');	//On inclus le fichier contenant les fonctions
		//include('controleur/config/controles_speciaux.php');	//On inclus le fichier gerant les fonctions
		
		$code = htmlspecialchars($_GET['code']);
		
		//$ign = htmlspecialchars($_GET['IGN']);
		//$took = htmlspecialchars($_GET['Took']);
		//$version = htmlspecialchars($_GET['Version']);
		
		$cheats_javaw = urldecode(htmlspecialchars($_GET['ClientsNameJavaw']));
		//$cheats_javaw_id = htmlspecialchars($_GET['StringsFoundJavaw']);
		
		$cheats_explorer = urldecode(htmlspecialchars($_GET['ClientsNameExplorer']));
		//$cheats_explorer_id = htmlspecialchars($_GET['StringsFoundExplorer']);
		
		/*$cheats_dwm = urldecode(htmlspecialchars($_GET['ClientsNameDWM']));*/
		/*$cheats_dwm_id = htmlspecialchars($_GET['StringsFoundDWM']);*/
		
		$cheats_lsass = urldecode(htmlspecialchars($_GET['ClientsNameLsass']));
		//$cheats_lsass_id = htmlspecialchars($_GET['StringsFoundLsass']);
		
		$date = date('Y-m-d H:i:s');
		
		$req = req('SELECT', '*', 'pin', 'Pin', $code);
		
		/*foreach($req[1] as $donnee)
		{
			if(sha1($donnee['Pin'] + $donnee['IdUser']) == $code)
			{
				$id = $donnee['Id'];
				$id_user = $donnee['IdUser'];
				$pin = $donnee['Pin'];
				break;
			}
		}*/
		
		//echo 'test24';
		
		if($req[0] == 0) //Regarde si le pin existe dans la bdd
		{
			//echo 'test254';
			return;
		}
		
		$id = $req[1]['Id'];
		/*$id_user = 0;
		$pin = 0;*/
		
		req('UPDATE', 'Used|ClientsNameJavaw|ClientsNameExplorer|ClientsNameLsass|Time', 'pin', 'Id', '1|'.$cheats_javaw.'|'.$cheats_explorer.'|'.$cheats_lsass.'|'.$date.'|'.$id);
		echo 'test';
	}
}
else
{
	echo 'tesazeza';
}
?>