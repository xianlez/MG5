# MG5
## Devlog

## 1. NavMesh vs. Physics-Based Movement

NavMesh is useful when a character needs to find a route across walkable ground and navigate around obstacles. It works well for click-to-move controls and AI characters because the developer can set a destination instead of manually controlling every movement along the route.

For example, an imagined strategy game where the player clicks to send units around buildings would benefit from NavMesh. Each unit needs to calculate a path and move toward its destination.

Physics-based movement is more appropriate when gravity, momentum, jumping, or forces are central to the gameplay. For example, an imagined platform game where a character jumps between platforms and gets pushed by moving obstacles would benefit from physics-based movement. A NavMesh alone would not provide those physical interactions.

## 2. BirdManager Loop and Distance Check

I fixed the loop to start at index `0` and continue while `i < _birds.Length`. After each iteration, `i++` advances to the next bird. This checks every entry in the array without accessing an index outside its bounds.

Inside the loop, `Bird bird = _birds[i]` gets the bird at the current index. `Vector3.Distance(bird.transform.position, _player.position)` calculates the straight-line distance between that bird and the player in world space.

The `if` statement checks whether this distance is less than or equal to `_interactDistance`. If it is, the script calls `bird.RunAway(_player.position)`, passing the player’s position so the bird can move away from the player.

Every bird in the `_birds` array is checked individually. Only birds within or exactly at the interaction distance will be told to run away; birds farther away will not. In my scene, the interaction distance is 3 Unity units, and all four birds are assigned to the array. I tested approaching each bird and confirmed that each one ran away.

## Open-Source Assets
- [Quirky animal 3D models](https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-free-animals-pack-178235)
- [Mountain fantasy environment models](https://www.fab.com/listings/60487a72-3f20-4bb2-aa78-247ed1582656)
