# Unity-Shmup-Starter

## Scenes :
Dans les préférences de compilation (Build Settings: Ctrl/Cmd + Shift + B), cliquer sur `[Add Open Scenes]` autant de fois que nécessaire (`Start`, `Stage-1` & `GameOver` doivent être dans la liste).
<br><img width="400" src="https://i.imgur.com/RE1YuKV.png">

## Physique :
Ne pas oublier de régler les collisions :  
- Layer (Inspector > Layer > Add Layer):  
<br><img width="300" src="https://i.imgur.com/eIshOkh.png">
	- `8:  PlayerShip`
	- `9:  PlayerBullet`
	- `10: EnemyShip`
	- `11: EnemyBullet`

- Collision matrix (Project Settings > Physics):  
<br><img width="300" src="https://i.imgur.com/MxERrAr.png">
