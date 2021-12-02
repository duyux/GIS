/*
 *    GeoTools - The Open Source Java GIS Toolkit
 *    http://geotools.org
 *
 *    (C) 2019, Open Source Geospatial Foundation (OSGeo)
 *
 *    This library is free software; you can redistribute it and/or
 *    modify it under the terms of the GNU Lesser General Public
 *    License as published by the Free Software Foundation;
 *    version 2.1 of the License.
 *
 *    This library is distributed in the hope that it will be useful,
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *    Lesser General Public License for more details.
 *
 */
package org.geotools.tutorial.quickstart;

import org.geotools.data.FileDataStore;
import org.geotools.data.FileDataStoreFinder;
import org.geotools.data.simple.SimpleFeatureSource;
import org.geotools.map.FeatureLayer;
import org.geotools.map.Layer;
import org.geotools.map.MapContent;
import org.geotools.styling.SLD;
import org.geotools.styling.Style;
import org.geotools.swing.JMapFrame;
import org.geotools.swing.data.JFileDataStoreChooser;

import java.io.File;
import java.io.IOException;

/**
 * @description:
 * @author: 都玉新
 * @time: 2021/11/22 13:50
 */
public class Quickstart {
    public static void testgeotools() throws IOException {
        File file= JFileDataStoreChooser.showOpenFile("shp",null);
        if(file==null){
            return;
        }

        FileDataStore store= FileDataStoreFinder.getDataStore(file);
        SimpleFeatureSource featureSource=store.getFeatureSource();

        //create a map content and add our shapefile to it
        MapContent map=new MapContent();
        map.setTitle("Quickstart");

        Style style= SLD.createSimpleStyle(featureSource.getSchema());
        Layer layer=new FeatureLayer(featureSource,style);
        map.addLayer(layer);

        //Now display the map
        JMapFrame.showMap(map);

    }
}
