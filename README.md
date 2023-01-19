# Simple-SO-Framework
My standard implementation of a simple SO framework, described in detail by the [Unite 2017 talk on Scriptable Objects](https://www.youtube.com/watch?v=raQ3iHhE_Kk)

# Scriptable Object Resetting
After runtime, Scriptable Objects keep their data and are not reset like MonoBehaviours. For variables that you want to reset, like health, you must reset the Scriptable Objects.
Because Scriptable Objects do not have the same callbacks as MonoBehaviours, it is difficult to estimate when the game is started. To fix this, we created a script called "SO Reset". Add this script to your introduction scene, or any scene which when loaded will automatically reset all Scriptable Objects.
