# LevelDesignerXML

This small project aims to describe Unity scenes geometry, light and physics in a XML format. It is designed to hook with a custom importer for octet [https://github.com/andy-thomason/octet], a C++ game framework.

It currently supports cube and sphere meshes, lights, cameras, rigidbodies and hinge joints.

In the example scenes you will find the basics: 

1 - Tag all objects that you want to export with the tag "export". A manager game object will consider all objects with that tag, and assign them special components.

2 - Run the scene and press the export button on the game window. A new XML file will be created on the assets folder.

3 - Use the XML as input for your Octet importer (You can find mine here: https://github.com/alejandroSaura/octet/tree/UnityXMLimporter).

4 - Have fun using Octet!

Video demo: https://www.youtube.com/watch?v=ks-I-f_m1AM

Last but not least, follow my developments on my personal blog:
https://alejandrosaura.wordpress.com/