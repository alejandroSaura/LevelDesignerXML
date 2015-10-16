# LevelDesignerXML

This small project aims to describe Unity scenes geometry, light and physics in a XML format.
It is designed to hook with a custom importer for octet [https://github.com/andy-thomason/octet], a C++ game framework.

Each gameObject being described must have the ExportInfo component, and then the corresponding scripts associated to the component to describe.
The main camera holds a main exporter script, which grabs all these descriptions and writes tehm on a XML file.

Once the setup is complete, run the scene and press the export button. A new XML file will be created on the assets folder.
