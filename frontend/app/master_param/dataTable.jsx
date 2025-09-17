// components/data-table.js
"use client";

import { useState, useMemo } from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import {
  Sheet,
  SheetContent,
  SheetDescription,
  SheetFooter,
  SheetHeader,
  SheetTitle,
  SheetTrigger,
} from "@/components/ui/sheet";
import { Label } from "@/components/ui/label";
import { MoreHorizontal, ChevronLeft, ChevronRight, X } from "lucide-react";

// Sample data - ganti dengan data Anda
const sampleData = [
  { code: "BCT", description: "Bacterial" },
  { code: "BIC", description: "Bioindicator Sample" },
  { code: "CMT", description: "Cosmetic" },
  { code: "DFT", description: "Disinfectant" },
  { code: "DLB", description: "Dialyzer" },
  { code: "FNB", description: "Food & Beverage" },
  { code: "H2O", description: "Water" },
  { code: "HSR", description: "Hand Sanitizer" },
  { code: "KIT", description: "Kit" },
  { code: "LQD", description: "Liquid" },
  // Tambahkan lebih banyak data untuk testing pagination
  { code: "MED", description: "Medical Device" },
  { code: "PHR", description: "Pharmaceutical" },
  { code: "CHM", description: "Chemical" },
  { code: "ENV", description: "Environmental" },
  { code: "TOX", description: "Toxicology" },
  { code: "MIC", description: "Microbiology" },
  { code: "BIO", description: "Biotechnology" },
  { code: "LAB", description: "Laboratory" },
];

export default function DataTable({ data = sampleData, columns }) {
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage, setItemsPerPage] = useState(10);
  const [searchTerm, setSearchTerm] = useState("");
  
  // State untuk sheet
  const [isEditSheetOpen, setIsEditSheetOpen] = useState(false);
  const [isDeleteSheetOpen, setIsDeleteSheetOpen] = useState(false);
  const [selectedItem, setSelectedItem] = useState(null);
  
  // State untuk form edit
  const [editForm, setEditForm] = useState({
    code: "",
    description: ""
  });

  // Filter data berdasarkan search
  const filteredData = useMemo(() => {
    return data.filter((item) =>
      Object.values(item).some((value) =>
        value.toString().toLowerCase().includes(searchTerm.toLowerCase())
      )
    );
  }, [data, searchTerm]);

  // Pagination logic
  const totalPages = Math.ceil(filteredData.length / itemsPerPage);
  const startIndex = (currentPage - 1) * itemsPerPage;
  const endIndex = startIndex + itemsPerPage;
  const currentData = filteredData.slice(startIndex, endIndex);

  // Reset to first page when search changes
  const handleSearch = (value) => {
    setSearchTerm(value);
    setCurrentPage(1);
  };

  // Reset to first page when items per page changes
  const handleItemsPerPageChange = (value) => {
    setItemsPerPage(parseInt(value));
    setCurrentPage(1);
  };

  const handlePreviousPage = () => {
    setCurrentPage((prev) => Math.max(prev - 1, 1));
  };

  const handleNextPage = () => {
    setCurrentPage((prev) => Math.min(prev + 1, totalPages));
  };

  // Action handlers
  const handleEdit = (item) => {
    setSelectedItem(item);
    setEditForm({
      code: item.code,
      description: item.description
    });
    setIsEditSheetOpen(true);
  };

  const handleDelete = (item) => {
    setSelectedItem(item);
    setIsDeleteSheetOpen(true);
  };

  const handleView = (item) => {
    console.log("View:", item);
    // Implementasi view logic
  };

  // Handler untuk save edit
  const handleSaveEdit = () => {
    console.log("Saving edit:", editForm);
    // Implementasi save logic di sini
    // Misalnya: updateData(selectedItem.id, editForm)
    setIsEditSheetOpen(false);
    setSelectedItem(null);
  };

  // Handler untuk confirm delete
  const handleConfirmDelete = () => {
    console.log("Deleting:", selectedItem);
    // Implementasi delete logic di sini
    // Misalnya: deleteData(selectedItem.id)
    setIsDeleteSheetOpen(false);
    setSelectedItem(null);
  };

  // Handler untuk input change
  const handleInputChange = (field, value) => {
    setEditForm(prev => ({
      ...prev,
      [field]: value
    }));
  };

  return (
    <div className="w-full space-y-4">
      {/* Header dengan Show entries dan Search */}
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-2">
          <span className="text-sm">Show</span>
          <Select
            value={itemsPerPage.toString()}
            onValueChange={handleItemsPerPageChange}
          >
            <SelectTrigger className="w-20">
              <SelectValue />
            </SelectTrigger>
            <SelectContent>
              <SelectItem value="10">10</SelectItem>
              <SelectItem value="25">25</SelectItem>
              <SelectItem value="50">50</SelectItem>
              <SelectItem value="100">100</SelectItem>
            </SelectContent>
          </Select>
          <span className="text-sm">entries</span>
        </div>

        <div className="flex items-center space-x-2">
          <span className="text-sm">Search:</span>
          <Input
            placeholder="Search..."
            value={searchTerm}
            onChange={(e) => handleSearch(e.target.value)}
            className="w-64"
          />
          <Button className="bg-green-600 hover:bg-green-700">Add</Button>
        </div>
      </div>

      {/* Table */}
      <div className="border rounded-lg">
        <Table>
          <TableHeader className="bg-green-600">
            <TableRow>
              <TableHead className="text-white font-medium">Code</TableHead>
              <TableHead className="text-white font-medium">Description</TableHead>
              <TableHead className="text-white font-medium text-center">Action</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {currentData.map((item, index) => (
              <TableRow 
                key={item.code} 
                className={index % 2 === 0 ? "bg-white" : "bg-gray-50"}
              >
                <TableCell className="font-medium">{item.code}</TableCell>
                <TableCell>{item.description}</TableCell>
                <TableCell className="text-center">
                  <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                      <Button variant="ghost" className="h-8 w-8 p-0">
                        <span className="sr-only">Open menu</span>
                        <MoreHorizontal className="h-4 w-4" />
                      </Button>
                    </DropdownMenuTrigger>
                    <DropdownMenuContent align="end">
                      <DropdownMenuItem onClick={() => handleView(item)}>
                        View
                      </DropdownMenuItem>
                      <DropdownMenuItem onClick={() => handleEdit(item)}>
                        Edit
                      </DropdownMenuItem>
                      <DropdownMenuItem 
                        onClick={() => handleDelete(item)}
                        className="text-red-600"
                      >
                        Delete
                      </DropdownMenuItem>
                    </DropdownMenuContent>
                  </DropdownMenu>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>

      {/* Pagination */}
      <div className="flex items-center justify-between">
        <div className="text-sm text-gray-700">
          Showing {startIndex + 1} to {Math.min(endIndex, filteredData.length)} of{" "}
          {filteredData.length} entries
          {searchTerm && ` (filtered from ${data.length} total entries)`}
        </div>

        <div className="flex items-center space-x-2">
          <Button
            variant="outline"
            size="sm"
            onClick={handlePreviousPage}
            disabled={currentPage === 1}
            className="flex items-center"
          >
            <ChevronLeft className="h-4 w-4" />
            Prev
          </Button>

          <div className="flex items-center space-x-1">
            {Array.from({ length: totalPages }, (_, i) => i + 1).map((page) => {
              // Show only a few pages around current page
              if (
                page === 1 ||
                page === totalPages ||
                (page >= currentPage - 1 && page <= currentPage + 1)
              ) {
                return (
                  <Button
                    key={page}
                    variant={currentPage === page ? "default" : "outline"}
                    size="sm"
                    onClick={() => setCurrentPage(page)}
                    className={
                      currentPage === page
                        ? "bg-green-600 hover:bg-green-700"
                        : ""
                    }
                  >
                    {page}
                  </Button>
                );
              }
              // Show ellipsis
              if (page === currentPage - 2 || page === currentPage + 2) {
                return <span key={page}>...</span>;
              }
              return null;
            })}
          </div>

          <Button
            variant="outline"
            size="sm"
            onClick={handleNextPage}
            disabled={currentPage === totalPages}
            className="flex items-center"
          >
            Next
            <ChevronRight className="h-4 w-4" />
          </Button>
        </div>
      </div>

      {/* Edit Sheet */}
      <Sheet open={isEditSheetOpen} onOpenChange={setIsEditSheetOpen}>
        <SheetContent>
          <SheetHeader>
            <SheetTitle>Edit Item</SheetTitle>
            <SheetDescription>
              Make changes to the selected item. Click save when you're done.
            </SheetDescription>
          </SheetHeader>
          
          <div className="grid gap-4 py-4">
            <div className="grid grid-cols-4 items-center gap-4">
              <Label htmlFor="code" className="text-right">
                Code
              </Label>
              <Input
                id="code"
                value={editForm.code}
                onChange={(e) => handleInputChange("code", e.target.value)}
                className="col-span-3"
              />
            </div>
            <div className="grid grid-cols-4 items-center gap-4">
              <Label htmlFor="description" className="text-right">
                Description
              </Label>
              <Input
                id="description"
                value={editForm.description}
                onChange={(e) => handleInputChange("description", e.target.value)}
                className="col-span-3"
              />
            </div>
          </div>
          
          <SheetFooter>
            <Button 
              variant="outline" 
              onClick={() => setIsEditSheetOpen(false)}
            >
              Cancel
            </Button>
            <Button onClick={handleSaveEdit} className="bg-green-600 hover:bg-green-700">
              Save Changes
            </Button>
          </SheetFooter>
        </SheetContent>
      </Sheet>

      {/* Delete Confirmation Sheet */}
      <Sheet open={isDeleteSheetOpen} onOpenChange={setIsDeleteSheetOpen}>
        <SheetContent>
          <SheetHeader>
            <SheetTitle>Delete Item</SheetTitle>
            <SheetDescription>
              Are you sure you want to delete this item? This action cannot be undone.
            </SheetDescription>
          </SheetHeader>
          
          {selectedItem && (
            <div className="py-4 space-y-4">
              <div className="p-4 border rounded-lg bg-gray-50">
                <div className="space-y-2">
                  <div>
                    <span className="font-medium text-gray-700">Code: </span>
                    <span className="text-gray-900">{selectedItem.code}</span>
                  </div>
                  <div>
                    <span className="font-medium text-gray-700">Description: </span>
                    <span className="text-gray-900">{selectedItem.description}</span>
                  </div>
                </div>
              </div>
              
              <div className="bg-red-50 border border-red-200 rounded-lg p-4">
                <div className="flex">
                  <div className="flex-shrink-0">
                    <X className="h-5 w-5 text-red-400" />
                  </div>
                  <div className="ml-3">
                    <h3 className="text-sm font-medium text-red-800">
                      Warning
                    </h3>
                    <div className="mt-2 text-sm text-red-700">
                      <p>
                        This will permanently delete the selected item and cannot be recovered.
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          )}
          
          <SheetFooter>
            <Button 
              variant="outline" 
              onClick={() => setIsDeleteSheetOpen(false)}
            >
              Cancel
            </Button>
            <Button 
              variant="destructive" 
              onClick={handleConfirmDelete}
            >
              Delete
            </Button>
          </SheetFooter>
        </SheetContent>
      </Sheet>
    </div>
  );
}


