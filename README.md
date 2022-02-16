# Netsol-Unity-Task
 This Repo is for Netsol Assignment of Wrld SDK.

"Main Task" Scene has All Tasks.

My Scripts Folder has All Scripts-related Tasks.

1.PLayerController.cs 
	--->has Basic Movement and Rotation of AirCraft(Player) through Movement(Up and Down Arrow Key) and Rotation(Left and Right Arrow Key) and Fire from AirCraft py Pressing 'F' Key.
         ---> Also Implemented AirCraft Movement by SetOriginMethod() Calling.

2.ObjectPool.cs
	-----> Manages Pool of Enemy And Bullets.
3.FindPointOnTransportNetwork.cs
  -----> has location of enemies on Roads.
4.EnemyHealth.cs
   ----> Manages Health of Enemies and disable enemy if health is less than zero.
5.CameraController.cs
-----> Follows the Camera to the AirCraft(Player).
6.Bullet.cs
-----> Bullet Follows Enemy OnEnable() Function and if Hit Enemy then Disable itSelf and Decrease Health of Enemy.
7.BuildingAltitudePicking.cs
-----> Generates Enemies on Buildings in Different Locations. 

MyMaterials and AirCraft Data Folder have AirCraft and Enemies Related Materials.


 1.Meets core requirement 1 ------- Done in PLayerController.cs Script
 2. Meets core requirement 2 ------- Done is BuildingAltitudePicking.cs Script
3. Meets core requirement 3 ------Done in FindPointOnTransportNetwork.cs Script
 4. Meets core requirement 4 ------ Done in Bullet Fire by Pressing 'F' Key in PLayerController.cs || Bullet.cs has Code to Follow Enemy ||ObjectPool.cs has Coroutine to activate disabled Enemy after some time.
5. Meets bonus requirement 1 ------- Done in PLayerController.cs Script
6. Meets bonus requirement 2 ------- Not Done 
7. Meets bonus requirement 3 --------Object.cs has All Pooling Code for Enemies and Bullets.



 
